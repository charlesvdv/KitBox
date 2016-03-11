--Commandes SQL pour selection données dans kittybox

-- Obtention code prix et nombre pour élément
-- if value is not needed use LIKE '%'
SELECT PK_code, prix, nbrpieces,hauteur,largeur,profondeur  FROM `element` WHERE `typeElement` LIKE 'panneau GD' AND `couleur` LIKE 'brun' AND `hauteur` LIKE '%' AND `largeur` LIKE 0 AND `profondeur` LIKE 32 

-- chercher la cornière la plus proche 
-- couleur DOIT être spécidfiée !!
SELECT PK_code, prix, nbrpieces,hauteur  FROM `element` WHERE `typeElement` LIKE 'corni' AND `couleur` LIKE 'brun' AND `hauteur` >= 100 LIMIT 1

-- creat commande
INSERT INTO `kitbox`.`commande` (`PK_refCommande`, `prix total`, `FK_client`, `date`) VALUES ('5', '856', '2', now());




-- add 1 link commande element
INSERT INTO `kitbox`.`linkcommandeelement` (`FK_element`, `FK_commande`, `quantiteTotale`, `prix`, `quantiteRetiree`) VALUES ('PAG3242BL', '6', '2', '12', '2');

-- add multiple elements 
INSERT INTO `kitbox`.`linkcommandeelement` (`FK_element`, `FK_commande`, `quantiteTotale`, `prix`, `quantiteRetiree`) VALUES ('PAR5252BR', '1', '4', '150', '4'), ('PAR5280BR', '1', '2', '54', '2');


-- rechercher commandes des 6 derniers mois
SELECT PK_refCommande FROM `commande` WHERE date BETWEEN now() - interval 6 month AND now()

-- rechercher liens commandes des 6 derniers mois
SELECT FK_element,quantitetotale FROM `linkcommandeelement` WHERE `FK_commande` IN (SELECT PK_refCommande FROM `commande` WHERE date BETWEEN now() - interval 6 month AND now())

-- select cheapest element
select FK_fournisseur,delai,prix from `linkelementfournisseur` where prix = (select min(prix) from `linkelementfournisseur`) and FK_element like "COR100BLDEC"

-- add client
INSERT INTO `kitbox`.`client` (`PK_client`, `telephone`, `adresse`, `nom`) VALUES (NULL, '0495107311', 'rue de l''invasion 114, 1340 OLLN', 'Riga Lorenzo');

-- delete client
DELETE FROM `client` WHERE `PK_client` = '%';

-- recherche client 
-- not case sensitve 
-- WARNING do not remove % around name example !!! Alows search with only a part of the name
SELECT * FROM `client` WHERE `nom` LIKE '%riga%'

-- select autogen client number 
SELECT PK_client FROM `client` WHERE `nom` LIKE '%riga%'

-- select best fournisseur
SELECT FK_fournisseur,prix,delai FROM linkelementfournisseur
where delai=
	(select min(delai) from linkelementfournisseur where FK_Element = 'COR100BLDEC' and prix = 
    	(select min(prix) from linkelementfournisseur where FK_Element = 'COR100BLDEC'))        
and FK_Element='COR100BLDEC'


-- count the command in the 6 months 
 select e.PK_code, sum(l.quantiteTotale) as tot from element e 
	inner join linkcommandeelement l on e.PK_code = l.FK_element 
	inner join commande on l.FK_commande = commande.PK_refCommande
	where commande.date between now() - interval 6 month and now()
	group by e.PK_code;
	
	
-- get best supplier (price and delai)
select prix, delai, FK_Element, FK_fournisseur from linkelementfournisseur l1
where (
	prix = (select min(prix) from linkelementfournisseur l2 
	where l2.FK_Element = l1.FK_Element order by delai))
	group by FK_Element;
	
-- SaveCommand save the supplier command in the database exemple
START TRANSACTION;
update element set reserve = reserve + 3 where PK_code= 'COR100BLDEC';
update element set reserve = reserve + 4 where PK_code ='COR100BRDEC';
COMMIT;

-- en dessous c's des essais pour getbestsupplier (bcp de merde !)

-- /!\ to test !!!!
-- select the best fournisseur 
select * from (
	select * from linkelementfournisseur 
	order by min(prix), min(delai) ) as l
	group by FK_Element

select prix, delai, l1.FK_fournisseur, l1.FK_Element from linkelementfournisseur as l1
where prix = (
	select l2.FK_Element, l2.prix,  l2.FK_fournisseur from linkelementfournisseur as l2 
	where l1.FK_Element = l2.FK_Element and min(price) )
and delai = (
		select l3.FK_Element, l3.prix, l3.delai, l3.FK_fournisseur from linkelementfournisseur as l3
		where l1.FK_Element=l3.FK_Element and l1.prix = l3.price and min(delai)
);


select prix, delai, l1.FK_fournisseur, l1.FK_Element from linkelementfournisseur as l1
where prix in (
	select l2.FK_Element, l2.prix,  l2.FK_fournisseur from linkelementfournisseur as l2 
	where l1.FK_Element = l2.FK_Element and min(price) )
	
	
select l1.FK_Element, l1.FK_fournisseur, l1.prix, l1.delai
from linkelementfournisseur l1
where l1.prix = min(l1.prix);

-- choose only the best price ! (TODO : best delai if the same)
select prix, delai, FK_Element, FK_fournisseur from linkelementfournisseur l1
where (
	select min(prix) from linkelementfournisseur l2 
	where l2.FK_Element = l1.FK_Element)
	group by FK_Element;
	
	

	
select prix, delai, FK_Element, FK_fournisseur from linkelementfournisseur l1
where (
	prix = (select min(prix) from linkelementfournisseur l2 
	where l2.FK_Element = l1.FK_Element order by delai))
	group by FK_Element;


