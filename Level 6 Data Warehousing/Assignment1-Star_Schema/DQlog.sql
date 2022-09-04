PRINT 'Drop DQLog if exists'

DROP TABLE IF EXISTS DQLog;

PRINT 'Creating DQLog table'

CREATE TABLE DQLog
(
	logID 		int				PRIMARY KEY			IDENTITY(1,1),
	rowID 		varchar(15)		NOT NULL,
	DBName 		varchar(20)		NOT NULL,
	tableName	varchar(20)		NOT NULL,
	ruleNo		smallint		NOT NULL,
	action		varchar(6)		CHECK (action IN ('allow','fix','reject'))
);

PRINT 'DQLog created';