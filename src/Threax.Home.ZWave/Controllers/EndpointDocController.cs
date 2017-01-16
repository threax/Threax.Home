﻿using Halcyon.HAL.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.Home.Core;

namespace Threax.Home.ZWave.Controllers
{
    [Route("[controller]")]
    public class EndpointDocController : Controller
    {
        IApiDescriptionGroupCollectionProvider descriptionProvider;

        public EndpointDocController(IApiDescriptionGroupCollectionProvider descriptionProvider)
        {
            this.descriptionProvider = descriptionProvider;
        }

        [HttpGet("{groupName}/{method}/{*relativePath}")]
        [HalRel(HalDocEndpointInfo.DefaultRels.Get)]
        public EndpointDescription Get(String groupName, String method, String relativePath)
        {
            if (relativePath.EndsWith("/") || relativePath.EndsWith("\\"))
            {
                relativePath = relativePath.Substring(0, relativePath.Length - 1);
            }

            var group = descriptionProvider.ApiDescriptionGroups.Items.First(i => i.GroupName == groupName);
            var action = group.Items.First(i => i.HttpMethod == method && i.RelativePath == relativePath);

            var description = new EndpointDescription();
            foreach (var param in action.ParameterDescriptions)
            {
                if (param.Source.IsFromRequest && param.Source.Id == "Body")
                {
                    description.RequestSchema = GetSchema(param.Type);
                }
            }

            var controllerActionDesc = action.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDesc != null)
            {
                var methodInfo = controllerActionDesc.MethodInfo;
                if (methodInfo.ReturnType != typeof(void))
                {
                    description.ResponseSchema = GetSchema(methodInfo.ReturnType);
                }
            }

            return description;
        }

        private JsonSchema4 GetSchema(Type type)
        {
            if (typeof(IAsyncResult).IsAssignableFrom(type))
            {
                type = type.GenericTypeArguments.First();
            }

            //Also make sure we have a HalModelAttribute on the class. 
            var typeInfo = type.GetTypeInfo();
            if (typeInfo.GetCustomAttribute<HalModelAttribute>() == null)
            {
                throw new InvalidOperationException($"{type.Name} is not a valid schema object. Declare a HalModel attribute on it to mark it valid.");
            }

            //Finally return the schema
            var t = JsonSchema4.FromTypeAsync(type, new NJsonSchema.Generation.JsonSchemaGeneratorSettings()
            {
                DefaultEnumHandling = EnumHandling.String,
                DefaultPropertyNameHandling = PropertyNameHandling.CamelCase,
                FlattenInheritanceHierarchy = true
            });
            t.Wait();
            return t.Result;
        }
    }
}
