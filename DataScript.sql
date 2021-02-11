--use [C:\USERS\ADZIU\DOCUMENTS\MASFINAL.MDF]

set identity_insert Insurance ON

insert into Insurance(InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 1,'Insurance 1', 100000.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance(InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 2,'Insurance 2', 250000.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 3,'Insurance 3', 50000.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 4,'Insurance 4', 4310321.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 5,'Insurance 5', 3213.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 6,'Insurance 6', 2321321.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 7,'Insurance 7', 321214.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 8,'Insurance 8', 321421512.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '
insert into Insurance (InsuranceID,Name, InsuranceAmount, InsuranceRange, GeneralTermsAndConditions) select 9,'Insurance 9', 30000.00, 'Lorem ipsum', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eget sodales odio. Phasellus ac ipsum id diam molestie blandit quis. '

set identity_insert Insurance OFF
set identity_insert InsurancePackage ON

insert into InsurancePackage(InsurancePackageID,[Name],[Description]) select 1,'Package 1', 'Ultra-package! Contains every single insurance package.'
insert into InsurancePackage(InsurancePackageID,[Name],[Description], InsurancePackageID1) select 2,'Package 2', 'A great package compromised of two seperate insurances!',1

set identity_insert InsurancePackage OFF

insert into InsurancesInPackages select 2,1
insert into InsurancesInPackages select 3,1

set identity_insert Person ON
insert into Person(PersonID, Name, Surname, PhoneNumber, Address) select 1, 'John', 'Cadence', '+52 421321423', 'Walnut Street 1, Warsaw, Poland' 
set identity_insert Person OFF

insert into Client(PersonID,SocialSecurityNumber) select 1, '2190323414'

set identity_insert InsuranceAgreement ON
insert into InsuranceAgreement(InsuranceAgreementID, Price, BuyDate, State, DateFrom, DateTo, AdditionalInfo, InsuranceID, InsurancePackageID, ClientID, InvoiceID)
select 1,'500', getdate(), 1, dateadd(week,1, getdate()),dateadd(week,1, getdate()), 'Special holiday offer', 3,null,1,null
set identity_insert InsuranceAgreement OFF

insert into Invoice select 'AX/2021/2312', getdate(), 'Oak Street 13, Gdansk, Poland', 'Payment by cash only', 1

update InsuranceAgreement set InvoiceID=1 where InsuranceAgreementID='1'

select * from InsurancePackage
select * from Insurance
select * from InsurancesInPackages
select * from Person
select * from Client
select * from InsuranceAgreement

