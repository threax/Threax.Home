import * as hr from 'hr.main';
import * as datetime from 'hr.bootstrap.datetime.main';
import * as bootstrap from 'hr.bootstrap.main';
import * as bootstrap4form from 'hr.form.bootstrap4.main';
import * as controller from 'htmlrapier/src/controller';
import * as WindowFetch from 'htmlrapier/src/windowfetch';
import * as AccessTokens from 'htmlrapier/src/accesstokens';
import * as whitelist from 'htmlrapier/src/whitelist';
import * as fetcher from 'htmlrapier/src/fetcher';
import * as client from './ServiceClient';
import * as userSearch from './UserSearchClientEntryPointInjector';
import * as loginPopup from 'htmlrapier.relogin/src/LoginPopup';
import * as deepLink from 'htmlrapier/src/deeplink';
import * as xsrf from 'htmlrapier/src/xsrftoken';
import * as pageConfig from 'htmlrapier/src/pageconfig';

hr.setup();
datetime.setup();
bootstrap.setup();
bootstrap4form.setup();

export interface Config {
    client: {
        ServiceUrl: string;
        PageBasePath: string;
    };
    tokens: {
        AccessTokenPath?: string;
        XsrfCookie?: string;
        XsrfPaths?: string[];
    };
}

var builder: controller.InjectedControllerBuilder = null;

export function createBuilder() {
    if (builder === null) {
        builder = new controller.InjectedControllerBuilder();

        //Set up the access token fetcher
        var config = pageConfig.read<Config>();
        builder.Services.tryAddShared(fetcher.Fetcher, s => createFetcher(config));
        builder.Services.tryAddShared(client.EntryPointInjector, s => new client.EntryPointInjector(config.client.ServiceUrl, s.getRequiredService(fetcher.Fetcher)));

        userSearch.addServices(builder);

        //Setup Deep Links
        deepLink.setPageUrl(builder.Services, config.client.PageBasePath);

        //Setup relogin
        loginPopup.addServices(builder.Services);
        builder.create("hr-relogin", loginPopup.LoginPopup);
    }
    return builder;
}

function createFetcher(config: Config): fetcher.Fetcher {
    var fetcher = new WindowFetch.WindowFetch();

    if (config.tokens !== undefined) {
        fetcher = new xsrf.XsrfTokenFetcher(
            new xsrf.CookieTokenAccessor(config.tokens.XsrfCookie),
            new whitelist.Whitelist(config.tokens.XsrfPaths),
            fetcher);
    }

    if (config.tokens.AccessTokenPath !== undefined) {
        fetcher = new AccessTokens.AccessTokenFetcher(
            config.tokens.AccessTokenPath,
            new whitelist.Whitelist([config.client.ServiceUrl]),
            fetcher);
    }

    return fetcher;
}