print '' print '*** Inserting Sample Users Records'
GO
INSERT INTO [dbo].[Users]
	([UserName], [DisplayName], [RankID], [Level], [CurrentXP])
	VALUES
	("bellitalic", "bellitalic", 14, 15, 45165),
	("waylonsultan","waylonsultan", 15, 15, 45259),
	("ochiltholus","ochiltholus", 13, 13, 38000),
	("centroidsownder","centroidsownder", 12, 12, 28900),
	("mulleropens","mulleropens", 11, 11, 27000),
	("haysupreme","haysupreme", 10, 10, 22000),
	("yardwave","yardwave", 9, 9, 18000),
	("kishornwomba","kishornwomba", 8, 8, 13500),
	("pigeonoscar","pigeonoscar", 7, 7, 11000),
	("egadfigurehead","egadfigurehead", 6, 6, 8800),
	("apparelcloaks","apparelcloaks", 5, 5, 7000),
	("reindependent","reindependent", 4, 4, 3800),
	("somberteith","somberteith", 3, 3, 2500),
	("dunitemugs","dunitemugs", 2, 2, 1500),
	("criticizedigress","criticizedigress", 1, 1, 500),
	("nadrideffect","nadrideffect", 0, 0, 150),
	("winterfatuous","winterfatuous", 0, 0, 100),
	("yeasttimely","yeasttimely", 10, 10, 23000),
	("leachrail","leachrail", 7, 7, 12000),
	("twittercopernicus","twittercopernicus", 6, 6, 9750),
	("calddefended","calddefended", 14, 14, 40000),
	("meerkatleaves","meerkatleaves", 11, 11, 28000)
GO


/*print '' print '*** Inserting Sample TestResults Records'
GO
INSERT INTO [dbo].[XPModifierInfo]
	([ModifierType], [RequiredValue], [ModifierValue])
	VALUES
	("wpm", 0.0, 1.0),
	("wpm", 50.0, 1.5),
	("wpm", 70.0, 2.0),
	("wpm", 100.0, 3.0),
	("time", 7.0, 3.0),
	("time", 12.0, 2.0),
	("time", 20.0, 1.5),
	("time", 200.0, 1.0)
GO*/