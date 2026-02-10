using Dynamicweb.Updates;
using System;

namespace Commergent.Dw.DemoApp.Infrastructure.Updates;

public class AppDemoUpdateProvider : UpdateProvider
{
    public override IEnumerable<Update> GetUpdates() => new List<Update>
    {
        new SqlUpdate("e07ebfa0-f81e-4e0d-ab5f-ec78d91f8400", this, @"
            CREATE TABLE [dbo].[CmgtDemoAppAuthenticationTokens]
            (
                [Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
                [Token] NVARCHAR(100) NOT NULL,
                [TokenType] NVARCHAR(20) NOT NULL,
                [Expiration] DATETIME NOT NULL,
                [Username] NVARCHAR(200),
                [DateCreated] DATETIME NOT NULL
            );
        "),

        SqlUpdate.AddTable("44b2df60-1005-4d1c-83c8-07d21c055c0c", this, "CmgtDemoAppLoginProvider", @"
            ( 
                [Id] [bigint] IDENTITY(1,1) NOT NULL,
                [Email] [nvarchar](200) NOT NULL,
                [CustomerId] nvarchar(100) NULL,
                [DateCreated] [datetime] NOT NULL,
                [DateModified] [datetime] NOT NULL,
                CONSTRAINT [PK_CmgtDemoAppLoginProvider] PRIMARY KEY CLUSTERED 
                (
                    [Id] ASC
                )
            )
        "),

        new FileUpdate("43d7ca04-5ef8-4abb-bca4-7559f73b8c83", this, "/Files/Templates/Designs/Swift-v2/Custom_DemoApp.cshtml", () => StreamHelper.GetViewsStream("DemoApp.cshtml"), overwrite: true), 
        // NOTE: If you want the file to be overwritten on each update (for scenarios where the template is not customizable by the user, but only by the application developer),
        // not only must the 'overwrite' parameter be set to true, but the update ID must also be changed to a new GUID, on each update.
        // Otherwise, Dynamicweb will not execute the update, as it may have already tracked the update ID

        new FileUpdate("f4defdbf-2c6a-4a62-963f-d4ab6222eeb5", this, "/Files/Templates/Designs/Swift-v2/Paragraphs/Custom_DemoParagraph.cshtml", () => StreamHelper.GetViewsStream("Paragraphs.DemoParagraph.cshtml"), overwrite: true),
    };
}

