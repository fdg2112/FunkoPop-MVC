CREATE DATABASE funkopop;

CREATE LOGIN admin_funkopop_store WITH PASSWORD = 'Funk0P0pF4cuFr4nc0S4nt1';
CREATE LOGIN appuser_funkopop_store WITH PASSWORD = 'Funk0P0pF4cuFr4nc0S4nt14pp';

USE funkopop;

CREATE USER admin_funkopop_store FOR LOGIN admin_funkopop_store;
CREATE USER appuser_funkopop_store FOR LOGIN appuser_funkopop_store;

GRANT ALTER, CONTROL, DELETE, EXECUTE, INSERT, REFERENCES, SELECT, UPDATE TO admin_funkopop_store;
GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO admin_funkopop_store;
GRANT SELECT, UPDATE ON SCHEMA::dbo TO appuser_funkopop_store;

-- Creación de tablas
CREATE TABLE [user] (
    id INT IDENTITY(1,1) PRIMARY KEY,
    uid VARCHAR(100) NOT NULL UNIQUE,
    lastname VARCHAR(255) NOT NULL CHECK (lastname NOT LIKE '%[^a-zA-Z]%'),
    firstname VARCHAR(255) NOT NULL CHECK (firstname NOT LIKE '%[^a-zA-Z]%'),
    email VARCHAR(45) UNIQUE NOT NULL CHECK (email LIKE '%_@__%.__%'),
    phone VARCHAR(20),
    role VARCHAR(10) NOT NULL CHECK (role IN ('admin', 'customer')),
    active BIT DEFAULT 1 NOT NULL
);

CREATE TABLE province (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(25) NOT NULL
);

CREATE TABLE location (
    id INT IDENTITY(1,1) PRIMARY KEY,
    postal_code VARCHAR(8) NOT NULL,
    name VARCHAR(50) NOT NULL,
    province_id INT NOT NULL REFERENCES province(id)
);

CREATE TABLE address (
    id INT IDENTITY(1,1) PRIMARY KEY,
    street_name VARCHAR(30) NOT NULL,
    street_number INT NOT NULL,
    floor INT,
    department VARCHAR(5),
    location_id INT NOT NULL REFERENCES location(id),
    user_id INT NOT NULL REFERENCES [user](id),
    active BIT DEFAULT 1 NOT NULL
);

CREATE TABLE collection (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(999) NOT NULL,
    active BIT DEFAULT 1 NOT NULL,
    url_image VARCHAR(400),
    ref_image VARCHAR(100)
);

CREATE TABLE product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    catalog_number INT NOT NULL UNIQUE,
    name VARCHAR(30) NOT NULL,
    description VARCHAR(999) NOT NULL,
    price FLOAT NOT NULL,
    stock INT NOT NULL,
    shine BIT NOT NULL DEFAULT 0,
    collection_id INT REFERENCES collection(id),
    active BIT DEFAULT 1 NOT NULL,
    url_image VARCHAR(400),
    ref_image VARCHAR(100)
);

CREATE TABLE consultation_product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    message VARCHAR(999) NOT NULL,
    response VARCHAR(999),
    product_id INT NOT NULL REFERENCES product(id),
    user_id INT NOT NULL REFERENCES [user](id),
    active BIT DEFAULT 1 NOT NULL
);

CREATE TABLE shipment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    shipment_date DATETIME NOT NULL,
    active BIT DEFAULT 1 NOT NULL
);

CREATE TABLE sale (
    id INT IDENTITY(1,1) PRIMARY KEY,
    operation_date DATE NOT NULL,
    payment_date DATE,
    sale_type VARCHAR(10) NOT NULL CHECK (sale_type IN ('Comun', 'Reserva')),
    address_id INT REFERENCES address(id),
    shipment_id INT REFERENCES shipment(id),
    user_id INT NOT NULL REFERENCES [user](id),
    active BIT DEFAULT 1 NOT NULL,
    payment_id INT NOT NULL,
    payment_total FLOAT NOT NULL,
    sale_status VARCHAR(10) NOT NULL CHECK (sale_status IN ('Success', 'Pending', 'Failure'))
);

CREATE TABLE sale_product (
    id INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT NOT NULL,
    product_id INT NOT NULL REFERENCES product(id),
    sale_id INT NOT NULL REFERENCES sale(id),
    active BIT DEFAULT 1 NOT NULL,
    unitary_total FLOAT NOT NULL
);

CREATE TABLE cart (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL REFERENCES [user](id),
    active BIT DEFAULT 1 NOT NULL,
	CONSTRAINT unique_user_id UNIQUE (user_id)
);

CREATE TABLE line_cart (
    id INT IDENTITY(1,1) PRIMARY KEY,
    quantity INT,
    total FLOAT,
    cart_id INT NOT NULL REFERENCES cart(id),
    product_id INT NOT NULL REFERENCES product(id),
    active BIT DEFAULT 1 NOT NULL
);

CREATE TABLE favorite (
    id INT PRIMARY KEY IDENTITY,
    product_id INT NOT NULL REFERENCES product(id),
    user_id INT NOT NULL REFERENCES [user](id)
);