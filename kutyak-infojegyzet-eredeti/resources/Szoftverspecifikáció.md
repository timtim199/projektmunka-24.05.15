# Állatorvosi nyilvántartó rendszer szoftverspecifikáció
> [Eredeti feladatleírás alapján](https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-180531/) \
> A szaktnár által javasolt kivitelezési iránymutatások alapján


## Cél

Megadott állatorvosi szöveges állományokra specializálódott konzolalkalmazás létrehozása.

### Felhasználói igények
- Konzol alkalmazás
- Szöveges állományok feldolgozása
- Különböző statisztikai adatok megjelenítése
- Statisztikai adatok egy részének mentése szöveges állományba

## Feladat elemzése
A megadott állományok alapján különböző adatokat kell feltüntetnünk, egy konzolos alkalmazásban. \
Három állomány áll számunkra rendelkezésre, ezt kell beolvasnunk, és elemeznünk.
Mindegyik adatállomány UTF-8 kódolású, pontosvesszővel tagolt szöveges fájl.
### Állományok megnevezése és leírása

|   **Fájlnév**   	|                                   **Leírás**                                  	|
|:---------------:	|:-----------------------------------------------------------------------------:	|
| KutyaNevek.csv  	| A kutyanevek ID és Név kapcsolatának leírása                                  	|
| Kutyak.csv      	| A rendelő pácienseinek listája                                                	|
| KutyaFajtak.csv 	| A fajták feltüntetett nevének, eredeti nevének és azonosítójának a kapcsolata 	|


### A feladat
- **Konzolalkalmazás**  létrehozása
- **Kutyanevek számának** kiírása **képernyőre** (3. feladat)
- Kutyák **átlagéletkora** megjelenítése a **képernyőn, 2 tizedesjegyes** kerekítés (6. feladat)
- **Legidősebb** kutya **nevének és fajtájának** kiírása **képernyőre** (3. feladat)
- **2018. január 10**-én **fajtánként hány kutya** volt a rendelőben (megjelenítés, 8. feladat)
- Annak a **napnak** a megjelenítése, amikor a **legjobban** le volt **terhelve** a rendelő (9. feladat)
- A **legforgalmasabb** napon ellátott **kutyák számának** a megjelenítése (9. feladat)
- **Névstatisztika.txt** néven létrehozott fájl, ahol **névszerint** feltüntetésre kerül **hány ugyan olyan nevű állat** van az állatorvosi állományban (10.feladat)
- névstatisztika.txt ';'-vel tagolt (10.feladat)
- névstatisztika.txt-ben a legtöbbször feltünő nevü kerül legelőre (10.feladat)

### Architektúra (aka. rendszerterv)
- .NET 5 keretrendszer

### Szükséges ismeretek
- Visual Studio Integrált fejleszőkörnyezet _(továbbiakban IDE)_ ismerete
- C# programozási nyelv ismerete
- .NET keretrendszer alapvető ismerete
- Rendezési metódusok alapvető ismerete
- OOP Irányelv ismerete

