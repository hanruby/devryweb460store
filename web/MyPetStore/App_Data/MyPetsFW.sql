DROP TABLE MyPetsFW
CREATE TABLE MyPetsFW
( 
	PID varchar (MAX) NOT NULL,
	product_code varchar (MAX) NOT NULL ,
	section varchar (MAX) NOT NULL ,
	category varchar (MAX) NOT NULL ,
	subcategories varchar (MAX) NOT NULL ,
	product_name varchar (MAX) NOT NULL ,
	product_description varchar (MAX) NOT NULL ,
	product_weight varchar (MAX) NOT NULL ,
	picture varchar (MAX) NOT NULL ,
	thumbnail varchar (MAX) NOT NULL ,
	product_size varchar (MAX) NOT NULL ,
	color varchar (MAX) NOT NULL ,
	pattern varchar (MAX) NOT NULL ,
	cost varchar (MAX) NOT NULL ,
	recommended_price varchar (MAX) NOT NULL ,
	shipping_surcharge varchar (MAX) NOT NULL ,
	min_quantity varchar (MAX) NOT NULL ,
	UPC varchar (MAX) NOT NULL ,
	QTY_available varchar (MAX) NOT NULL
)

BULK INSERT MyPetsFW
    FROM 'c:\WEB460\topdawgproducts.csv' 
    WITH 
    ( 
	FIRSTROW = 2,
        FIELDTERMINATOR = ',', 
        ROWTERMINATOR = '\n' 
    )

SELECT * FROM MyPetsFW;