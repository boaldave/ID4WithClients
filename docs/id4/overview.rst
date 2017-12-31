ID4 Implementation Overview
===========================
This project is intended to demonstrate a single implementation of ID4 Authentication for several Client Applications. ID4 will be configured to authenticate the same User Credentials across all Client Applications.

Authentication Flow by UI Technology
------------------------------------

Each of the Client Application technologies require specific Authentication Flows to ensure security resilience. Here is what has been implemented:

================ ================= ================= ======
UI Application   Technology        Auth Flow         Spec
================ ================= ================= ======
Login UI         Angular           Implicit Flow     OpenID
User Manager     Angular           Implicit Flow     OpenID
User Profile UI  Angular           Implicit Flow     OpenID
User Profile UI  ASP.Net MVC Core  Resource Owner    OAuth2
User Profile UI  ASP.Net WebForms  Resource Owner    OAuth2
User Profile UI  Xamarin           Hybrid Auth Code  OpenID
================ ================= ================= ======

Inspiration and Credits
-----------------------

**Eric Anderson**

Eric created a series on IdentityServer 4 that helped further my understanding beyond the IdentityServer4 documentation's QuickStarts. If any information on this site is unclear, I recommend you read Eric's work (https://elanderson.net/2017/05/identity-server-introduction/).

**IdentityServer4 Documentation**

IdentityServer4's site of course is an important source of information to get started using ID4.  Important sections of the site include Topics, Reference, Endpoints, and QuickStarts which will help you wrap your head around the multitude of topics possible regarding Authorization as a Service (https://identityserver4.readthedocs.io/en/release/index.html).

**OpenID Connect Specs**

The source is always the best place to get definitive answers (http://openid.net/connect/).  The **OpenID Connect Working Group** is the governing body that defined the **OpenID Connect** spec on which IdentityServer4 is build. IdentityServer4 has received OpenID Connect certification.

The most important place to start learning the **OpenID Connect 1.0 specification** is at `Core Documentation <http://openid.net/specs/openid-connect-core-1_0.html>`_. Yes it is 86 pages, but that's short for spec and is well worth the read.

**ReadTheDocs.org and Eric Holscher**

You may notice that ID4 hosts their documentation on ReadTheDocs.org, as will be all my personal documentation going forward.  I appreciate everything MediaWiki is, but now I know about this other option: **Plaintext Markup Syntax/Html Parsing Build System** using Python, Sphinx, ReStructuredText, and MarkDown. Never thought I would use or write code in Python, but that is about to change, and yes, the ASP.Net Core Team has integrated it with .Net for API Documentation.  Easily written and read plain text documentation can now be source-controlled, then Html built and hosted on my or any file system. I can push my docs to Github, and WebHook them to ReadTheDocs.org which will build my reST files into nicely themed and freely Hosted Html. Github also understands reST and thus also nicely themes your reST docs. If you would like to learn more about Sphinx, reStructuredText (reST), and ReadTheDocs.org, visit the following links: `Eric Holscher: Sphinx and ReadTheDocs.org for Technical Writers <http://ericholscher.com/blog/2016/jul/1/sphinx-and-rtd-for-writers/>`_ and his matching `PyCon 2016 Youtube Video <https://www.youtube.com/watch?v=hM4I58TA72g>`_ (yes it's a 2:40:55 minute video, but over an hour is a workshop you can skip), `Sphinx - a Python Doc Generator <http://www.sphinx-doc.org/en/stable/contents.html>`_, and theming your reST docs with the `ReadTheDocs Theme <https://github.com/rtfd/sphinx_rtd_theme#via-package>`_.