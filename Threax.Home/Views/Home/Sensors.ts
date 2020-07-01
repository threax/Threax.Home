import * as standardCrudPage from 'hr.widgets.StandardCrudPage';
import * as startup from 'clientlibs.startup';
import * as deepLink from 'hr.deeplink';
import { SensorCrudInjector } from 'clientlibs.SensorCrudInjector';

var injector = SensorCrudInjector;

var builder = startup.createBuilder();
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());