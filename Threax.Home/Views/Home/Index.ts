import * as controller from 'hr.controller';
import * as startup from 'clientlibs.startup';
import * as deepLink from 'hr.deeplink';
import * as client from 'clientlibs.ServiceClient';
import * as iter from 'hr.iterable';

export class ButtonGroup {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, controller.InjectControllerData];
    }

    constructor(bindings: controller.BindingCollection, private data: client.ButtonResult) {

    }

    public async pressButton(evt: Event): Promise<void> {
        evt.preventDefault();
        this.data.apply({
            buttonStateId: (<any>evt.srcElement).value
        });
    }
}

export class ButtonGroupController {
    public static get InjectorArgs(): controller.DiFunction<any>[] {
        return [controller.BindingCollection, client.EntryPointInjector, controller.InjectedControllerBuilder];
    }

    constructor(bindings: controller.BindingCollection, private entryPointInjector: client.EntryPointInjector, private builder: controller.InjectedControllerBuilder) {
        var mainButtons = bindings.getView("mainButtons");
        this.setup(mainButtons);
    }

    private async setup(mainButtons: controller.IView<any>): Promise<void> {
        var entry = await this.entryPointInjector.load();
        var buttons = await entry.listButtons({
            limit: 10000,
        });

        //var items = new iter.Iterable(buttons.items).select(i => i.data);

        mainButtons.setData(buttons.items, this.builder.createOnCallback(ButtonGroup));
    }
}

var builder = startup.createBuilder();
builder.Services.addTransient(ButtonGroup, ButtonGroup);
builder.Services.addShared(ButtonGroupController, ButtonGroupController);
builder.create("buttons", ButtonGroupController);