import * as standardCrudPage from 'hr.widgets.StandardCrudPage';
import * as startup from 'clientlibs.startup';
import * as deepLink from 'hr.deeplink';
import { ButtonCrudInjector } from 'clientlibs.ButtonCrudInjector';

var injector = ButtonCrudInjector;

var builder = startup.createBuilder();
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());