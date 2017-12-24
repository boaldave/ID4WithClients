Welcome to CodeQwik's IdentityServer4 Adventures
================================================

IdentityServer4 (ID4) is an OpenID Connect and OAuth 2.0 framework for ASP.NET Core.
- the docs are `here: <https://identityserver4.readthedocs.io/en/release/>`_

The purpose of this site is host our implementations of the following applications and is intended to help other Organizations extend their knowledge of 3rd party Authentication of ASP.Net WebForms, to Xamarin, and Angular.io UI's.

**PLEASE USE ANY AND ALL INFORMATION ON THIS SITE AT YOUR OWN RISK. NOTHNG ON THIS SITE HAS BEEN VALIDATED BY ANY SECURITY EXPERTS AND THIS DOCUMENT IS PROBABLY IN DRAFT FORM AT THIS VERY MOMENT. WE INVITE YOU TO SUGGEST CORRECTIONS AS SOON AS WE GET OUR BLOG UP AND RUNNING AGAIN AT www.codeqwik.net.**

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
Centralized login logic and varying workflow for the following types of applications: Web UI (Angular.io, ASP.Net MVC, ASP.Net WebForms), Native Mobile (Xamarin), Web Services (ASP.Net Core).

Both Independent and Single Sign-on / Sign-out
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
Independent sign-on (and out) is when you login to A Browser app, and also have to login to a Xamarin Mobile App app even if you run them at the same time with the same user. Single sign-on (and out) allows you to login (and out) once over multiple application types. You sign-in to one, and you are signed in to them all.

Access Control for APIs by Client Application
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
Issue access tokens for APIs for various types of clients, e.g. server to server, web applications, SPAs and native/mobile apps.

Federation Gateway
^^^^^^^^^^^^^^^^^^
Support for external identity providers like Azure Active Directory, Google, Facebook etc. This shields your applications from the details of how to connect to these external providers.

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: Introduction

   intro/preamble

.. toctree::
   :maxdepth: 2
   :hidden:
   :caption: ID4 Customization

   id4/overview
   id4/database_customizations
   id4/client_credentials
   id4/resource_owner_passwords
   id4/interactive_login
   id4/external_authentication
   id4/hybrid_and_api_access
   id4/aspnet_identity
   id4/javascript_client
   id4/entity_framework
 
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
