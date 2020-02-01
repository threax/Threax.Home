import * as startup from 'clientlibs.startup';
import * as buttonGroupController from 'clientlibs.ButtonGroupController';
import * as thermostatController from 'clientlibs.ThermostatController';
import * as refresh from 'clientlibs.RefreshButton';

var builder = startup.createBuilder();
buttonGroupController.addServices(builder);
thermostatController.addServices(builder);
refresh.addServices(builder);

buttonGroupController.createControllers(builder);
thermostatController.createControllers(builder);
refresh.createControllers(builder);