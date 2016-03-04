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