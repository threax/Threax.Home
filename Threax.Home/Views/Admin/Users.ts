import * as startup from 'Client/Libs/startup';
import * as controller from 'htmlrapier/src/controller';
import * as crudService from 'htmlrapier.roleclient/src/UserCrudService';
import * as deepLink from 'htmlrapier/src/deeplink';
import * as userSearch from 'htmlrapier.roleclient/src/UserSearchController';

var builder = startup.createBuilder();
deepLink.addServices(builder.Services);
crudService.addServices(builder);

crudService.createControllers(builder, new crudService.UserCrudSettings());