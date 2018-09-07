import * as startup from 'clientlibs.startup';
import * as buttonGroupController from 'clientlibs.ButtonGroupController';
import * as thermostatController from 'clientlibs.ThermostatController';

var builder = startup.createBuilder();
buttonGroupController.addServices(builder);
thermostatController.addServices(builder);

buttonGroupController.createControllers(builder);
thermostatController.createControllers(builder);