.. _refuserprofileng:

Overview
========

The majority of the documentation will discuss the `GitHub Angular App written by Eric Anderson <https://github.com/elanderson/Angular-Core-IdentityServer>`_.

NG Code
=======

Services
--------

AuthService
^^^^^^^^^^^

The Angular **AuthService** derives from the popular OPENID Connect Certified `**angular-auth-oidc-client** Library from Damien Bod <https://github.com/damienbod/angular-auth-oidc-client>`_, importing 2 references from the library:

.. code-block:: javascript

   import { OidcSecurityService, OpenIDImplicitFlowConfiguration } 
       from 'angular-auth-oidc-client';

The configuration settings are established in the AuthService cstr:

.. code-block:: javascript

   openIdImplicitFlowConfiguration
       .stsServer = identityUrl;
       .redirect_url = originUrl + 'callback';
       .client_id = 'ng';
       .response_type = 'id_token token';
       .scope = 'openid profile apiApp';
       .post_logout_redirect_uri = originUrl + 'home';
       .forbidden_route = '/forbidden';
       .unauthorized_route = '/unauthorized';
       .auto_userinfo = true;
       .log_console_warning_active = true;
       .log_console_debug_active = false;
       .max_id_token_iat_offset_allowed_in_seconds = 10;

Here is the link to `angular-auth-oidc-client API documentation <https://github.com/damienbod/angular-auth-oidc-client/blob/master/API_DOCUMENTATION.md>`_, explaining the meanings of those configuration settings:

* ``.stsServer`` - ID4 DomainName
* ``.redirect_url`` - Url the Browser is told to Redirect to after successful login (a hash is added by ID4 to the query string when the redirect response is sent to the browser),
* ``.client_id`` - Client App Name
* ``.response_type`` - Type(s) of tokens requested. ``id_token token`` means both an IDToken and an AccessToken. The IDToken enables the validation of the User.  The AccessToken enables access to resources.
* ``.scope`` - Types of claims requested to be returned in the access token (id token?). Scopes requested by client must match the STS server configuration. In this case scope requested is ``openid profile apiApp`` which is access to IDToken, User Profile (usually Name, etc), and Api Resource called "apiApp".
* ``.post_logout_redirect_uri`` - Url the Browser is told to Redirect to after logout.
* ``.forbidden_route`` - Url the Browser is told to Redirect to if the route is forbidden,
* ``.unauthorized_route`` - Url the Browser is told to Redirect to if the route is unauthorized,
* ``.auto_userinfo`` - Automatically get user info after authentication, will make a request to UserProfile endpoint.
* ``.log_console_warning_active`` - Console Logging
* ``.log_console_debug_active`` - Console Logging
* ``.max_id_token_iat_offset_allowed_in_seconds`` - offset is Token Issuance vs Use, saves the number of nonces that need to be stored in ID4.

The AuthService cstr then calls ``openIdImplicitFlowConfiguration.setupModule()`` and when complete, ''AuthService.doCallbackLogicIfRequired()`` is called which is a passthrough to ``oidcSecurityService.getIsAuthorized()``.

The object referencing the AuthService can (with passthroughs to ``oidcSecurityService``):

#. Call ``getIsAuthorized()`` which will populate ``isAuthorized`` on a subscribed basis whenever the response returns.

#. If the user is ``!isAuthorized``, a call can be made to ``login()`` (which may take some time, assuming they are redirected to a login screen).

#. When the User wants to logout, a call can be made to ``logout()``.

#. On a timer a call can be made to ``refreshSession()``, which is similar to the login() call.

#. Can call ``get, put, post, delete`` methods which set RequestOptions (the Bearer Token in the AuthHeader), then passes through the http action.

Components
----------

nav-menu
^^^^^^^^

LOH-NEXT - What is next?

   C:\Github\EricAnderson-Angular-WebApi-ID4\ClientApp\ClientApp\app\components\services\auth.service.ts


ID4 Code
========

EndPoints
---------
