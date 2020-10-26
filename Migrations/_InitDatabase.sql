delete from dbo.mtd_category_form;
insert into dbo.mtd_category_form (id,[name],[description],[parent]) values ('17101180-9250-4498-BE4E-4A941AD6713C','Default','Default Group','17101180-9250-4498-BE4E-4A941AD6713C');

delete from dbo.mtd_sys_type;
SET IDENTITY_INSERT dbo.mtd_sys_type ON;
insert into dbo.mtd_sys_type (id,[name],[description],active) values (1,'Text','Text',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (2,'Integer','Integer',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (3,'Decimal','Decimal',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (4,'Memo','Memo',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (5,'Date','Date',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (6,'DateTime','DateTime',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (7,'File','File',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (8,'Image','Image',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (11,'List','List',1);
insert into dbo.mtd_sys_type (id,[name],[description],active) values (12,'Checkbox','Checkbox',1);
SET IDENTITY_INSERT dbo.mtd_sys_type OFF;


delete from dbo.mtd_sys_term;
SET IDENTITY_INSERT dbo.mtd_sys_term ON;
insert into dbo.mtd_sys_term (id,[name],[sign]) values (1,'equal','=');
insert into dbo.mtd_sys_term (id,[name],[sign]) values (2,'less','>');
insert into dbo.mtd_sys_term (id,[name],[sign]) values (3,'more','<');
insert into dbo.mtd_sys_term (id,[name],[sign]) values (4,'contains','~');
insert into dbo.mtd_sys_term (id,[name],[sign]) values (5,'no equal','<>');
SET IDENTITY_INSERT dbo.mtd_sys_term OFF;


delete from dbo.mtd_sys_style;
SET IDENTITY_INSERT dbo.mtd_sys_style ON;
insert into dbo.mtd_sys_style (id,[name],[description],active) values (4,'Line','Line',1);
insert into dbo.mtd_sys_style (id,[name],[description],active) values (5,'Column','Column',1);
SET IDENTITY_INSERT dbo.mtd_sys_style OFF;



