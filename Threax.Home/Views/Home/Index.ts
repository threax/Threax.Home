import * as startup from 'clientlibs.startup';
import * as buttonGroupController from 'clientlibs.ButtonGroupController';

var builder = startup.createBuilder();
buttonGroupController.addServices(builder);
buttonGroupController.createControllers(builder);