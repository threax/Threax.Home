import * as controller from 'hr.controller';
import * as startup from 'clientlibs.startup';
import * as menu from 'hr.appmenu.AppMenu';
import * as client from 'clientlibs.ServiceClient';

class AppMenuInjector extends menu.AppMenuInjector<client.EntryPointResult> {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private entryPointInjector: client.EntryPointInjector) {
        super();
    }

    public * createMenu(entry: client.EntryPointResult): Generator<menu.AppMenuItem> {
        yield { text: "Buttons", href: "Buttons" };
        yield { text: "Switches", href: "Switches" };
        yield { text: "Sensors", href: "Sensors" };
        yield { text: "Thermostats", href: "Thermostats" };
        yield { text: "Thermostat Settings", href: "ThermostatSettings" };
        yield { text: "Api Explorer", href: "ApiExplorer" };

        if (entry.canListUsers()) {
            yield { text: "Users", href: "Admin/Users" };
        }
    }

    public getEntryPoint(): Promise<client.EntryPointResult> {
        return this.entryPointInjector.load();
    }
}

const builder = startup.createBuilder();
menu.addServices(builder.Services, AppMenuInjector);
builder.create("appMenu", menu.AppMenu);