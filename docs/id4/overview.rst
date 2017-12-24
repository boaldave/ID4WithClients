IdentityServer4 Customizations
==============================
Most of ID4 configuration setting, instead of being hard-coded in the ASP.Net Core startup.cs file, can be set in database tables. The scripts below will set configurations to support the Authorization Flows for all the various technologies and will establish claims for users.

We are not using ID4 for Authorization, only Authentication and have  developed a separate Authorization Service.

Here is a screen shot of the IdentityServer4 Database Objects:

.. image:: images/ClientAppRelatedTables.png
   :align: center

.. image:: images/IdentityResourcesRelatedTables.png
   :align: center

.. image:: images/ApiResourcesRelatedTables.png
   :align: center

.. image:: images/PersistedGrantTable.png
   :align: center
   
Database Script:
^^^^^^^^^^^^^^^^
Client App Related Tables:

IdentityResources Related Tables:

Api Resources Related Tables:

Persisted Grant Table:

There are no configuration records in the Persisted Grant table. These represent the tokens created.
