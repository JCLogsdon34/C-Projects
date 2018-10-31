DROP DATABASE IF EXISTS Services;

CREATE DATABASE Services;

USE Services;

CREATE TABLE Services.Army
(serial_number INT NOT NULL AUTO_INCREMENT, 
name varchar(150) NOT NULL,
rank varchar(150) NOT NULL,
home_address varchar(250) NOT NULL,
home_city VARCHAR(50) NOT NULL, 
home_state varchar(50),
home_zip varchar(50),
 PRIMARY KEY (serial_number),
 INDEX name (name),
 INDEX rank (rank),
 INDEX home_address (home_address),
 INDEX home_city (home_city),
 INDEX home_state (home_state),
 INDEX home_zip (home_zip)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Services.Navy
(serial_number INT NOT NULL AUTO_INCREMENT, 
name varchar(150) NOT NULL,
rank varchar(150) NOT NULL,
home_address varchar(250) NOT NULL,
home_city VARCHAR(50) NOT NULL, 
home_state varchar(50),
home_zip varchar(50),
 PRIMARY KEY (serial_number),
 INDEX name (name),
 INDEX rank (rank),
 INDEX home_address (home_address),
 INDEX home_city (home_city),
 INDEX home_state (home_state),
 INDEX home_zip (home_zip)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Services.Marines
(serial_number INT NOT NULL AUTO_INCREMENT, 
name varchar(150) NOT NULL,
rank varchar(150) NOT NULL,
home_address varchar(250) NOT NULL,
home_city VARCHAR(50) NOT NULL, 
home_state varchar(50),
home_zip varchar(50),
 PRIMARY KEY (serial_number),
 INDEX name (name),
 INDEX rank (rank),
 INDEX home_address (home_address),
 INDEX home_city (home_city),
 INDEX home_state (home_state),
 INDEX home_zip (home_zip)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Services.Air_Force
(serial_number INT NOT NULL AUTO_INCREMENT, 
name varchar(150) NOT NULL,
rank varchar(150) NOT NULL,
home_address varchar(250) NOT NULL,
home_city VARCHAR(50) NOT NULL, 
home_state varchar(50),
home_zip varchar(50),
 PRIMARY KEY (serial_number),
 INDEX name (name),
 INDEX rank (rank),
 INDEX home_address (home_address),
 INDEX home_city (home_city),
 INDEX home_state (home_state),
 INDEX home_zip (home_zip)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Covert_OP_Has_Army
(Cov_Has_Army_ID INT NOT NULL,
serial_number INT NOT NULL, 
op_mem_id INT NOT NULL,
PRIMARY KEY Cov_Has_Army_ID(Cov_Has_Army_ID),
KEY serial_number(serial_number),
KEY op_mem_id(op_mem_id)
)ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Covert_OP_Has_Navy
(Cov_Has_Navy_ID INT NOT NULL,
serial_number INT NOT NULL, 
op_mem_id INT NOT NULL,
PRIMARY KEY Cov_Has_Navy_ID(Cov_Has_Navy_ID),
KEY serial_number(serial_number),
KEY op_mem_id(op_mem_id)
)ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Covert_OP_Has_Marines
(Cov_Has_Marine_ID INT NOT NULL,
serial_number INT NOT NULL, 
op_mem_id INT NOT NULL,
PRIMARY KEY Cov_Has_Marine_ID(Cov_Has_Marine_ID),
KEY serial_number(serial_number),
KEY op_mem_id(op_mem_id)
)ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Covert_OP_Has_Airforce
(Cov_Has_Airforce_ID INT NOT NULL,
serial_number INT NOT NULL, 
op_mem_id INT NOT NULL,
PRIMARY KEY Cov_Has_Airforce_ID(Cov_Has_Airforce_ID),
KEY serial_number(serial_number),
KEY op_mem_id(op_mem_id)
)ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Covert_Operation_Member
(op_mem_id int NOT NULL AUTO_INCREMENT,
op_id int NOT NULL,
Cov_Has_Army_ID INT NULL,
Cov_Has_Navy_ID INT NULL,
Cov_Has_Marine_ID INT NULL,
Cov_Has_Airforce_ID INT NULL,
PRIMARY KEY op_mem_id (op_mem_id),
KEY op_id (op_id),
KEY Cov_Has_Army_ID(Cov_Has_Airforce_ID),
KEY Cov_Has_Navy_ID(Cov_Has_Navy_ID),
KEY Cov_Has_Marine_ID(Cov_Has_Marine_ID),
KEY Cov_Has_Airforce_ID(Cov_Has_Airforce_ID)
)ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

CREATE TABLE Covert_Op
(op_id int NOT NULL AUTO_INCREMENT,
op_name varchar(250) NOT NULL,
PRIMARY KEY op_id(op_id),
INDEX op_name (op_name)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1;

ALTER TABLE Covert_Operation_Member
ADD CONSTRAINT fk_Covert_Operation_Member_op_id
FOREIGN KEY (op_id) REFERENCES Covert_Op(op_id) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Covert_Operation_Member
ADD CONSTRAINT fk_Covert_Operation_Member_Cov_Has_Army_ID
FOREIGN KEY (Cov_Has_Army_ID) REFERENCES Covert_OP_Has_Army(Cov_Has_Army_ID) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Covert_Operation_Member
ADD CONSTRAINT fk_Covert_Operation_Member_Cov_Has_Navy_ID
FOREIGN KEY (Cov_Has_Navy_ID) REFERENCES Covert_OP_Has_Navy(Cov_Has_Navy_ID) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Covert_Operation_Member
ADD CONSTRAINT fk_Covert_Operation_Member_Cov_Has_Marine_ID
FOREIGN KEY (Cov_Has_Marine_ID) REFERENCES Covert_OP_Has_Marines(Cov_Has_Marine_ID) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE Covert_Operation_Member
ADD CONSTRAINT fk_Covert_Operation_Member_Cov_Has_Airforce_ID
FOREIGN KEY (Cov_Has_Airforce_ID) REFERENCES Covert_OP_Has_Airforce(Cov_Has_Airforce_ID) ON DELETE NO ACTION ON UPDATE NO ACTION;

SELECT *
FROM Covert_Op
INNER JOIN Covert_Operation_Member ON Covert_Op.op_id = Covert_Operation_Member.op_id
INNER JOIN Covert_OP_Has_Army ON Covert_Operation_Member.Cov_Has_Army_ID = Covert_OP_Has_Army.Cov_Has_Army_ID
INNER JOIN Army ON Covert_OP_Has_Army.serial_number = Army.serial_number
WHERE name = "Desert Fox";

SELECT *
FROM Covert_Op
INNER JOIN Covert_Operation_Member ON Covert_Op.op_id = Covert_Operation_Member.op_id
INNER JOIN Covert_OP_Has_Navy ON Covert_Operation_Member.Cov_Has_Navy_ID = Covert_OP_Has_Navy.Cov_Has_Navy_ID
LEFT JOIN Navy ON Covert_OP_Has_Navy.serial_number = Navy.serial_number
WHERE Covert_Operation_Member.Cov_Has_Navy_ID <> null;

SELECT *
FROM Covert_Op
INNER JOIN Covert_Operation_Member ON Covert_Op.op_id = Covert_Operation_Member.op_id
INNER JOIN Covert_OP_Has_Army ON Covert_Operation_Member.Cov_Has_Army_ID = Covert_OP_Has_Army.Cov_Has_Army_ID
INNER JOIN Army ON Covert_OP_Has_Army.serial_number = Army.serial_number
INNER JOIN Covert_OP_Has_Navy ON Covert_Operation_Member.Cov_Has_Navy_ID = Covert_OP_Has_Navy.Cov_Has_Navy_ID
INNER JOIN Navy ON Covert_OP_Has_Navy.serial_number = Navy.serial_number
INNER JOIN Covert_OP_Has_Marines ON Covert_Operation_Member.Cov_Has_Marine_ID = Covert_OP_Has_Marines.Cov_Has_Marine_ID
INNER JOIN Marines ON Covert_OP_Has_Marines.serial_number = Marines.serial_number
INNER JOIN Covert_OP_Has_Airforce ON Covert_Operation_Member.Cov_Has_Airforce_ID = Covert_OP_Has_Airforce.Cov_Has_Airforce_ID
INNER JOIN Air_force ON Covert_OP_Has_Airforce.serial_number = Air_force.serial_number
HAVING name = 'Desert Storm';

