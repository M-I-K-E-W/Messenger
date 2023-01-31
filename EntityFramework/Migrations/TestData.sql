USE [Messenger]
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 
GO
INSERT [dbo].[Messages] ([Id], [SenderUserId], [RecipientUserId], [TimeStamp], [MessageBody]) VALUES (1, 1, 2, CAST(N'2023-01-26T14:05:11.340' AS DateTime), N'1st test message')
GO
INSERT [dbo].[Messages] ([Id], [SenderUserId], [RecipientUserId], [TimeStamp], [MessageBody]) VALUES (2, 1, 2, CAST(N'2023-01-26T14:07:01.217' AS DateTime), N'2nd test message')
GO
INSERT [dbo].[Messages] ([Id], [SenderUserId], [RecipientUserId], [TimeStamp], [MessageBody]) VALUES (3, 1, 2, CAST(N'2023-01-26T14:07:47.267' AS DateTime), N'3rd test message')
GO
INSERT [dbo].[Messages] ([Id], [SenderUserId], [RecipientUserId], [TimeStamp], [MessageBody]) VALUES (4, 1, 2, CAST(N'2023-01-26T14:08:11.420' AS DateTime), N'4th test message')
GO
INSERT [dbo].[Messages] ([Id], [SenderUserId], [RecipientUserId], [TimeStamp], [MessageBody]) VALUES (49, 1, 2, CAST(N'2023-01-30T18:03:32.277' AS DateTime), N'ffffffffffff')
GO

SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [Password], [FailedAttempts]) VALUES (1, N'mike.williams.business@outlook.com', N'123456', 0)
GO
INSERT [dbo].[Users] ([Id], [Email], [Password], [FailedAttempts]) VALUES (2, N'mike_williams_business@outlook.com', N'123456', 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
