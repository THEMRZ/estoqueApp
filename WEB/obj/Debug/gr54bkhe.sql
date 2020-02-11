CREATE TABLE [dbo].[Produto] (
    [ProdutoId] [int] NOT NULL IDENTITY,
    [Nome] [varchar](250) NOT NULL,
    [PrecoCusto] [decimal](18, 2) NOT NULL,
    [PrecoVenda] [decimal](18, 2) NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    [DataAtualizacao] [datetime] NOT NULL,
    [Liberado] [bit] NOT NULL,
    [Excluido] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Produto] PRIMARY KEY ([ProdutoId])
)
CREATE TABLE [dbo].[ProdutoComposto] (
    [ProdutoComposicaoId] [int] NOT NULL IDENTITY,
    [Quantidade] [int] NOT NULL,
    [ProdutoComposicao_ProdutoId] [int],
    [ProdutoId_ProdutoId] [int],
    [Produto_ProdutoId] [int],
    CONSTRAINT [PK_dbo.ProdutoComposto] PRIMARY KEY ([ProdutoComposicaoId])
)
CREATE TABLE [dbo].[RequisicaoProduto] (
    [RequisicaoId] [int] NOT NULL,
    [ProdutoId] [int] NOT NULL,
    [PrecoAtual] [decimal](18, 2) NOT NULL,
    [Quantidade] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RequisicaoProduto] PRIMARY KEY ([RequisicaoId], [ProdutoId])
)
CREATE TABLE [dbo].[Requisicao] (
    [RequisicaoId] [int] NOT NULL IDENTITY,
    [DataRequisicao] [datetime] NOT NULL,
    [Usuario_Id] [varchar](100),
    CONSTRAINT [PK_dbo.Requisicao] PRIMARY KEY ([RequisicaoId])
)
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] [varchar](100) NOT NULL,
    [Email] [varchar](256),
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [varchar](100),
    [SecurityStamp] [varchar](100),
    [PhoneNumber] [varchar](100),
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime],
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [varchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] [int] NOT NULL IDENTITY,
    [UserId] [varchar](100) NOT NULL,
    [ClaimType] [varchar](100),
    [ClaimValue] [varchar](100),
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] [varchar](100) NOT NULL,
    [ProviderKey] [varchar](100) NOT NULL,
    [UserId] [varchar](100) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey], [UserId])
)
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] [varchar](100) NOT NULL,
    [RoleId] [varchar](100) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId])
)
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] [varchar](100) NOT NULL,
    [Name] [varchar](256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_ProdutoComposicao_ProdutoId] ON [dbo].[ProdutoComposto]([ProdutoComposicao_ProdutoId])
CREATE INDEX [IX_ProdutoId_ProdutoId] ON [dbo].[ProdutoComposto]([ProdutoId_ProdutoId])
CREATE INDEX [IX_Produto_ProdutoId] ON [dbo].[ProdutoComposto]([Produto_ProdutoId])
CREATE INDEX [IX_RequisicaoId] ON [dbo].[RequisicaoProduto]([RequisicaoId])
CREATE INDEX [IX_ProdutoId] ON [dbo].[RequisicaoProduto]([ProdutoId])
CREATE INDEX [IX_Usuario_Id] ON [dbo].[Requisicao]([Usuario_Id])
CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName])
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId])
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId])
CREATE INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId])
CREATE INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId])
CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]([Name])
ALTER TABLE [dbo].[ProdutoComposto] ADD CONSTRAINT [FK_dbo.ProdutoComposto_dbo.Produto_ProdutoComposicao_ProdutoId] FOREIGN KEY ([ProdutoComposicao_ProdutoId]) REFERENCES [dbo].[Produto] ([ProdutoId])
ALTER TABLE [dbo].[ProdutoComposto] ADD CONSTRAINT [FK_dbo.ProdutoComposto_dbo.Produto_ProdutoId_ProdutoId] FOREIGN KEY ([ProdutoId_ProdutoId]) REFERENCES [dbo].[Produto] ([ProdutoId])
ALTER TABLE [dbo].[ProdutoComposto] ADD CONSTRAINT [FK_dbo.ProdutoComposto_dbo.Produto_Produto_ProdutoId] FOREIGN KEY ([Produto_ProdutoId]) REFERENCES [dbo].[Produto] ([ProdutoId])
ALTER TABLE [dbo].[RequisicaoProduto] ADD CONSTRAINT [FK_dbo.RequisicaoProduto_dbo.Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([ProdutoId])
ALTER TABLE [dbo].[RequisicaoProduto] ADD CONSTRAINT [FK_dbo.RequisicaoProduto_dbo.Requisicao_RequisicaoId] FOREIGN KEY ([RequisicaoId]) REFERENCES [dbo].[Requisicao] ([RequisicaoId])
ALTER TABLE [dbo].[Requisicao] ADD CONSTRAINT [FK_dbo.Requisicao_dbo.AspNetUsers_Usuario_Id] FOREIGN KEY ([Usuario_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserClaims] ADD CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserLogins] ADD CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[AspNetUserRoles] ADD CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id])
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202002090132461_AutomaticMigration', N'WEB.Migrations.Configuration',  0x1F8B0800000000000400ED5DDB6EE4B8117D0F907F10F41878DDBE640713C3DE85A7C74E8C8C3DCEB43DC9DB8096E8B630BAF4E8326B27C897E5219F945F08A92BC53B254ADD5E2CFCE296C8AA62F154912C91C5FFFDE7BFA73F3F47A1F31DA65990C467EEE1FE81EBC0D84BFC205E9FB945FEF8C35BF7E79F7EFFBBD30B3F7A763E37E58E71395433CECEDCA73CDF9C2C1699F7042390ED4781972659F298EF7B49B4007EB2383A38F8D3E2F07001110917D1729CD34F459C07112C7FA09FCB24F6E0262F40789DF830CCEAE7E8CDAAA4EADC8008661BE0C133F7EF17EFF6AB52AE731E060049B082E1A3EB80384E729023F94EEE33B8CAD3245EAF36E80108EF5E3610957B0461066BB94FBAE2BA4D3838C24D5874151B525E91E5496448F0F0B8D6C982AE3E48B36EAB33A4B50BA4DDFC05B7BAD4DC997B9B267E9127AE43F33A5986292E47EA75BF2EBDE7A0677B6DA7236CE0BF3D6759847991C2B31816790AC23DE7B6780803EFAFF0E52EF90AE3B3B80843521C24107AD77B801E21261B98E62F9FE0635FC82BDF7516FDEA0BBA7E5B9BAD5AB5E62ACE8F8F5CE70689021E42D8F63DD1F2559EA4F0CF308629C8A17F0BF21CA6A8EBAE7C586A8F118262799344B0E186C086ECC575AEC1F30718AFF3A733F7E847642197C133F49B27B504F77180CC0B55CAD30272249473BD4DA1972C712736BCDF432F8840E83AF855509BF15BD759790053E5294183C56718FB603216EF410E96C0071932D29609EA85BB2032570926768E7D47F04FE081F1F43E040F08127E4BE85D928410C4C6742E9EBDB00806D0B901DF837589513ECA9749B4494A047C8261592E7B0A36951B6C6CF70B53F6324DA24F49D891A18B7C592545EA614C27F27277205DC35C5FEC4FF05B8150E32530AB49655CD19B7220A13893C20B0BB56235E28B4B360D251B70BAE89CA68E2BED146BE2529B5A5B72AD157BAC92114EB64F642E77FBB702A0723EF0A18AE7206B0A4ACF21B6A716FC9C5A8C65890B8B6C4C52C3D4DA88A150BF39B8B4B21957BEAEF8A8244F6C6D1B634C57D3CA987A73DB5927006B60B6E73C7D5E46363174F6A431712847E2C9260E937981290624DA58D44397E9882AF0592C23B2824CF4EE8986F444614BD66E6CE6BB64DF762DD6DEC889E7C7A48A4DA7C713CCEB06C0513DBBE36057B725F75901D240654C5FDA623C999BB712C3698B8C3297F3CD0641B914F33E83A9A6CD50B5E6369C21E6D21909677D7D7830C9FAFA220241285DD6BFD162ABC16599C48F411A417FEC42F31664D92F49EAFF05644F16342667B6825E912240AE72106D26E776FB94C4F0A6881E30CEE7E365AD6BEE7E492E8187FCF7458C6B8DA6F721F1BE26457E11FBD87FDFE71EEBCE35095811E7DCF360965D2230437F9914713E6E02891D13FECF82FD0D1ED496210822FE3846B9D02F4DD16E34E0976046044131D359E087641DC47AA23645C5A2562594A2D6C58C27AC88989EA47549B1A06501A59C55A951E36C33BFC2F4CA1E928DB4D76D6CFE3CDBDCC07CBFA9BD5FD1BD4C114DE4A4BFEE3364F71CEDCADD807DA43B601F1F3E3C1EBFFDF10DF08FDFFC111EFF38FFE03DFD0C17AB721B9385B2FB30D3C9C7A692D3671016B6590DB286D209D8B78692ECEE5B4329267AFC3DF0F1AC442FC8531646E4B5CA377836B5394AB2B9CDA1D7CCB999CFE30306990B1E8BEC5B0BA6BAFBC6C287323FB6821A3404F5DBF2FE8DBC3B8638FB687B1D487B2D11866D2F70B0B9F0A7E2647F7FA98B75F370F62D3309E7143199819F6759E205A554FC6FAD9C8F6FFD46A375B163FC25AEEA09CEC731D42F08B7015E582069CFDC3F304A36E1D70630197E349F83FDFD435A63846E06A90C21DD5074F26BDF942A22BE15CEA31A666B844260F13E8901E26A3110EB4353EF064A117FE31249ADF1C1AB939BF325571F311A7B3D945DC0EA1F0D1930C58E0AE0106C8606A420CED9F12588BD6003425D512802661F7B718FB51CE937EFE106C6D8B3EAEA7FB4282D476A385569CE007682589A0809AAC05A0703E6EB880A0E4A261CAC7142432A540F429DBCD93AFD3C126B7295E808205C006C03657518541700744C74129451115501CAEA90CB2C28EB377B0B28EBABE4D5A1AC0A61EBF63F15CF9E0463FD68B80062D5C2711684F5DABC0580F5F4B1F3F8E2EC4050CF98D8ED08BC49D9B0D918B38F411FB5A326F0D28D24FA9348DE26A7C966ACBC2D2C3A3D31D9BC951548C700141B1BC7CC5ED9EEB021D00C76C989978870210B9EB0DE98E78965EE5E127799DFD78B9B3A83A3176B420B53DC08F42468AA2260A84E8E6AC0949D49BC7FC02FE173CE89E5A286D5E1DCAC0E07D2C8C0C45730EF2FF632D7E9026FF4AA9901179F44138090D0EA62140A9ADCFD830C558E3FD6A72BA5A72454C7401912CC18A7A0C32C177944396B4A03B2CD060F29D97A116140B6DE8D21A55AF912559F2808718910B6C32051762083A8A77D8A8336F921A1E4B6D15C7B61BCCA90E8318705FBD9A3AFB7E13AC5BE505B977484D930C66C5B77445879529DB107ED841A93079E8D42CF1A4D328A349B687F80AE240729586D6946A40D63D2440BB9E38E4479EA30F4340813ED376455A6134D3589A712EDA9C740897A14615382166F1CB4AEA56624546B89170D3489078ED21215F61368A9698C752DD5E3B15A499C609641386B948AFA512B8186EA86587451DD310F996FE287627483317C6FA4E98598F08B4ACB563C36396FD671DAA2D08C7970C6AAEBE6C463F43A638012791B2A58D5A9C208BA8104B2193CA3D00D195832B4669747BBC66DDF9D2EAAAC2EF583D38520FDCBE935D86C82784DA483A99F38AB2A17CCF2879579B294A8A2B1F07A7AA657E42DA73C49C11A526F116B24E9659066393E5EF700F00E9CA51F31C5B82B7AC152A961492DDAD94E6CD6504D05FC7F5589CD38C0097CD4D52E51BB221C3A29775FB35318B6A683F3F18010A4ECC6CF66B9B04CC2228A95DF98C5B4AAB42A2499EA893E0532454A5F9CEEB921B53A1B0A43AD7EAE4FAD9FF884A4D77F6346B197FD8426DA7BA94FB7CB824212EC9EEA53EAF2A09094BAA72CA5D3050551261EC7D800E595689B32B2B86EE533CEF444EB3C7D1314535098623F4707C72865994064F4C903F82459F2F9CE74286FB630B04BD928A479A76AD010A9BDFFB58354BCFC3B881228567C3699F881F191F5F35F3FC4C6436B14A6B609263AC5003D068963EE5BEC3AD1545BABD3E84F00E63DA7A4205236DD69665D551F70EF0DC5D523431AC419698618F1CEC08BF48EB1F7FC48EF8D3E45EAAC3A49927A6520257922BD2724F962103D8146F925F439B067D049EAEC5B8339227B1ABD3759645F0FA0CD91997EA74F9573609D24CC79AD4FBB3BBD4E92EC9EEE8CE3E38461077A41F69BA5B91FD4A0318D276CF674D1BD65468538034C12221E1BD2AA4FF932C4EAE73B89226124DD1845D527EA712812D0107B9ADEA9D9BEA3911EF515D3BC258FC252F36BF15160313D33ACEE0022449F0D8C01516E0C1887073E8969DD42B395A837BB166C2FDADEE2C546278DEC20B3CE19E7F1D9D1795B23733F6ACE0D43C936B8E8449D78F50CC34CF87B812CBE24DBA9C2AA74401882202B094C6065B772DA688270BFE28421376923D0BCDF0FCA9DA757193EF8DB1EFA1DA833FAB38D2D8C36E7A975B189CB4F86C96E0790152C22729363B0DB0FF53AB127D3912DCCB11BAE6488634B5BC39B68739615B4D9C79A68EFD7EB44DA8438E3ED0451046EBB82FAF1594E4F89B7786876123B6FADA858409178338BA66C43A3CEE32123D6821A2BCC2E06BA483B53AC9FB4BFDB5D0CF50E02F5CD36CC9682AA08CE9E5D2D1ACFDCD54B96C3681F17D85F7D0B9761007190AA29700DE2E01166799555C53D3A383CA22EC9D99D0B6B1659E6F752C99ADC5A7315FBF0F9CCFD97F3EF6D5F341360FD2BF3D799E68821EE96F90E52EF09A4ECE532A36F8EF1A7BF39C63A0BDECD313E527A6EF1E698C1F4E89B631E827CF4AD316A1A166F2EB16256935D323289A9B1370A946C86DDA0C05F7B1164C51AC7744E9CAB7F7096A32DA93DE7638ABCFC8973803A8810512BBB316F863E48329284058946CB33441AAB37918CB39A6D5F19A2AB6DB2AE48D1C36E1B31C6DF48F6F42D25D607A9213EC5CE6D19D3417104B86CBB6CFE851683476D7279404DB93440D9D5EEA3924E2468C51B49F78CCC9126913719A59A677ECD027F86FBC6743CE15FAA30640EC6BB5041A3E583AF4FB0449B7359827DCA56142CBA1661082DE195083C87A0D358FE15094344135E8F30648A495F8EA0EDA49A8AE5E33DE72ABB8F836F057A71879441B92ACAEC6C6540E6ECEB98C35B4D32FAF4D30D9B0D15B8A6EE30312C03BD258367F3CD0F226C35BBFCB8B9CD2BCBDA6E6BA0BD6573B2DB22BD4543B099867D1CAC66CF6FBE6587D34F7A6E224C5573CE4E67B796BCA629F2A0B11E3779FAB17E8244DDF6B229F7BF0B0F4D5B3D28F5552337FB45CC208AE398E4BB527CBCD60BD3CABF35CF90484D801E75CEF2DF5033376A54BB60E6438B691AF7DFB0323756B68E14F3DCF60658910185F3D5605C86D15702169D53B286BC773E17BDAD9CCD9CFC7FDBCF383F67CE4ED921228385D7EEE7959F023175D064FBD9E3E7468CE8C0D08E23C62847FC1480A9A2215B4F053F375C04A755760C2D0619DF47404531DB653FB11A278F7F2D0891A660E06143B6AD762B135BA344F88353D0EFDA0CD7B0DFA64B62FF2B4F596F354BFD36471FC5A1C5DD187AB69E869ECD6D47F7697DBE81DEA7DD858BE9B573B595FDCCF51FB0A7A822CEED4B06325CF25D6845C48638E42366679C9E9E70620C634E191EEBE139EC819CAB8A9D920F334560983125781CAB2B61F9C94769969CA52CC3945346CE56904E58C6BB5E144979D765E4BC05497A65BC2B1727655D159173E6E7E4143156305531E433DBA91CFDBC4CDC1C3F2A89E84A0E062ACE0E0D578BF534FBAF430D9366CEDF71154C9E107FA81A84839E2083E17855CC97E5BED714C51D2EAAD02C41497D71CB2E27B5B7A294DE502AC8C7635F2953E5B0B7A21272B0E567A4B1E945ACE5ACB7A50A76FE4A1F879EC2894E9CA35EB3295B76A813679DE7829A07E8594CC320CB3C7B0E1B2D9C8B186F11AF7EBD8759B0EE48E0C3E531F47A4BE6B6CC55FC98342B774AA2A608B59FEB1AE6C0C7074ED33C78045E8E5EE3DDE141BC769D72A72D3EC1F000FDABF863916F8A1C3519460F616FEF298E00C8F897A9F4FB329F7EDCE05F998D26203103BCABFE63FCAE0842BF95FB92B3754C40028716EACDD8B82F73BC297BFDD252BA49624D42B5FADA88C81D8C362122967D8C57E03B1C221B82DF07B806DECB6DBB19574444DD117DB59FBE0FC03A055156D3E8EAA39F08C37EF4FCD3FF01502729CB8EA70000 , N'6.4.0')

