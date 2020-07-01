import * as startup from 'Client/Libs/startup';
import * as buttonGroupController from 'Client/Libs/ButtonGroupController';
import * as thermostatController from 'Client/Libs/ThermostatController';
import * as refresh from 'Client/Libs/RefreshButton';

var builder = startup.createBuilder();
buttonGroupController.addServices(builder);
thermostatController.addServices(builder);
refresh.addServices(builder);

buttonGroupController.createControllers(builder);
thermostatController.createControllers(builder);
refresh.createControllers(builder);