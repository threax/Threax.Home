import * as standardCrudPage from 'htmlrapier.widgets/src/StandardCrudPage';
import * as startup from 'Client/Libs/startup';
import * as deepLink from 'htmlrapier/src/deeplink';
import { SwitchCrudInjector } from 'Client/Libs/SwitchCrudInjector';

var injector = SwitchCrudInjector;

var builder = startup.createBuilder();
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());