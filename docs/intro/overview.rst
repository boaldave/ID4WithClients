Welcome to CodeQwik's IdentityServer4 Adventures
================================================

.. image:: images/logo.png
   :align: center

IdentityServer4 (ID4) is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core.
- the docs are here: https://identityserver4.readthedocs.io/en/release/

The purpose of this site is to watch us code production ready implementations of the following applications:

The applications built will include the following:
- Custom Implementation of IdentityServer4
- Login UI and User Manager - Technology: Angular.io
- User Profile UI - Technology: Angular.io
- User Profile UI - Technology: ASP.Net MVC Core
- User Profile UI - Technology: ASP.Net WebForms
- User Profile Web Service - Technology: ASP.Net Core

The applications built will demonstrate the following ID4 Features:

Authentication as a Service
^^^^^^^^^^^^^^^^^^^^^^^^^^^
Centralized login logic and workflow for all of your applications (web, native, mobile, services).

Both Independent and Single Sign-on / Sign-out
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
Single sign-on (and out) over multiple application types.

Access Control for APIs by Client Application
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
Issue access tokens for APIs for various types of clients, e.g. server to server, web applications, SPAs and
native/mobile apps.

Federation Gateway
^^^^^^^^^^^^^^^^^^
Support for external identity providers like Azure Active Directory, Google, Facebook etc.
This shields your applications from the details of how to connect to these external providers.

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: Introduction

   intro/overview

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: ID4 Customization

   ID4/overview
   ID4/client_credentials
   ID4/resource_owner_passwords
   ID4/interactive_login
   ID4/external_authentication
   ID4/hybrid_and_api_access
   ID4/aspnet_identity
   ID4/javascript_client
   ID4/entity_framework
 
.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: Login UI and User Manager

   loginandusermanager/overview
   loginandusermanager/register_user
   loginandusermanager/login
   loginandusermanager/logout
   loginandusermanager/forgot_password
   loginandusermanager/reset_password
   loginandusermanager/terms_and_conditions
   loginandusermanager/user_manager

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: User Profile UI - Angular.io

   userprofileng/overview
   userprofileng/code

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: User Profile UI - ASP.Net MVC

   userprofilemvc/overview
   userprofilemvc/code

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: User Profile UI - ASP.Net WebForms

   userprofilewebforms/overview
   userprofilewebforms/code


.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: User Profile WebService

   userprofilewebservice/overview
   userprofilewebservice/code
