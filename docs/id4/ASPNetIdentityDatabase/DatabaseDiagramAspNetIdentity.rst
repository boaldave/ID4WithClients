.. _refDatabaseDiagramAspNetIdentity:

Database Diagram: AspNetIdentity Database
=========================================

There are no configuration scripts for Users, this was a deliberate decision. We decided to start with no users in ID4, forcing users to register their existing username (''Register User'' is discussed later), but we could have imported all of our existing users from our WebForms FormsAuth Authentication system. The catch, however, is there is no way to transfer passwords, users have to reset their password (''Password Reset'' is discussed later). When you force users to register their Username they can use their existing password in the prior Authentication system.  

Please also note we developed a separate Authorization Service and are not using ID4 User Claims for Authorization, only Authentication.

.. image:: images/ASPNetIdentityTables.png
   :align: left
