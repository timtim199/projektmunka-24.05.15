# Állatorvosi nyilvántartó rendszer tesztelési terv
> [Eredeti feladatleírás alapján](https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-180531/) \
> A táblázatok [elérhetőek](@bin/tesztelesi-terv.xlsx) excel formátumban is. 
## Tartalomjegyzék
- [Állatorvosi nyilvántartó rendszer tesztelési terv](#állatorvosi-nyilvántartó-rendszer-tesztelési-terv)
  - [Tartalomjegyzék](#tartalomjegyzék)
  - [Bevezetés](#bevezetés)
  - [Tesztelés menete](#tesztelés-menete)
  - [Bemenetek összesítése](#bemenetek-összesítése)
  - [KutyaNevek.csv](#kutyanevekcsv)
    - [Mintavétel](#mintavétel)
    - [ECP](#ecp)
    - [BLA](#bla)
  - [Kutya.csv](#kutyacsv)
    - [Mintavétel](#mintavétel-1)
    - [ECP](#ecp-1)
    - [BLA](#bla-1)
  - [KutyaFajta.csv](#kutyafajtacsv)
    - [Mintavétel](#mintavétel-2)
    - [ECP](#ecp-2)
    - [BLA](#bla-2)

## Bevezetés
A szoftver bemenetei kizárólag struktúrált szöveges fájlokon keresztül érkeznek, tehát ebből a szempontból lesz megközelítve a tesztelés.

\
Két módszer kerül alkalmazásra:
- Ekvalencia particionálás (továbbiakban **ECP**)
- Határérték-analízis (továbbiakban **BLA**)
- A BLA tesztelések elvégzésére manuális
- Az ECP tesztelés megközelítésére autómatizált tesztelési módszer kerül alkalmazásra

## Tesztelés menete
1. A tesztelést három fő részre osztjuk, mivel három fájl található
2. Minden fáj a strúktúra oszlopaival egyenlő kisebb tesztrészből áll, tehát minden oszlop külön-külön kerül vizsgálatra
3. Minden oszlop viszgálatra kerül ECP és BLA módszer által.

> Minden fájlból mintavétel kerül ezen dokumentumba

## Bemenetek összesítése
Tehát a fentiek szerint, három bemenő fájlunk van, ami a következőket tartalmazzák:

|   **Fájlnév**   	|                                   **Leírás**                                  	|
|:---------------:	|:-----------------------------------------------------------------------------:	|
| KutyaNevek.csv  	| A kutyanevek ID és Név kapcsolatának leírása                                  	|
| Kutyak.csv      	| A rendelő pácienseinek listája                                                	|
| KutyaFajtak.csv 	| A fajták feltüntetett nevének, eredeti nevének és azonosítójának a kapcsolata 	|




## KutyaNevek.csv

### Mintavétel
| ID  | KUTYANÉV |
| --- | -------- |
| 1   | Akina    |
| 288 | Zseni    |
| 182 | Marcus   |

### ECP
| **Bemenet**  | **ID** | **Érvényes (VECP)** | **Érvénytelen (IECP)** | **** |
|--------------|--------|---------------------|------------------------|------|
| **ID**       | 1      | >= 1                | <1                     |      |
| ****         | 2      |                     | Üres                   |      |
| ****         | 3      |                     | Nem egész szám         |      |
| ****         | 4      |                     | Nem szám               |      |
| **Kutyanév** | 5      | ABC Betüi           | Üres                   |      |
| ****         | 6      |                     | Nem betű               |

### BLA
> Itt külön kitérünk  az int maximális értékének a tesztelésére

| **Bemenet** | **ID** | **Érték**  | **Határérték** | **Eredmény** |
|-------------|--------|------------|----------------|--------------|
| **ID**      | 1      | 1          | 1              | T            |
| ****        | 2      | 0          | 1              | F            |
| ****        | 3      | 2          | 1              | T            |
| ****        | 4      | 2147483648 | 2147483647     | T            |


## Kutya.csv
### Mintavétel
| **id** | **fajta_id** | **név_id** | **életkor** | **utolsó orvosi ellenőrzés** |
|--------|--------------|------------|-------------|------------------------------|
| 1      | 307          | 107        | 14          | 2017.11.27                   |
| 2      | 329          | 62         | 9           | 2018.01.24                   |
| 48     | 58           | 59         | 4           | 2018.01.22                   |
| 49     | 346          | 113        | 10          | 2017.03.23                   |
| 589    | 390          | 35         | 11          | 2018.01.25                   |
| 590    | 274          | 103        | 18          | 2017.04.11                   |

### ECP
| **Bemenet**                      | **ID** | **Érvényes (VECP)**         | **Érvénytelen (IECP)** |
|----------------------------------|--------|-----------------------------|------------------------|
| **id**                           | 1      | >= 1                        | <1                     |
| ****                             | 2      |                             | Üres                   |
| ****                             | 3      |                             | Nem egész szám         |
| ****                             | 4      |                             | Nem szám               |
| **fajta_id**                     | 5      | >= 1                        | <1                     |
| ****                             | 6      | KutyaFajtak.csv tartalmazza | Üres                   |
| ****                             | 7      |                             | Nem egész szám         |
| ****                             | 8      |                             | Nem szám               |
| **név_id**                       | 9      | >= 1                        | <1                     |
| ****                             | 10     | KutyaNevek.csv tartalmazza  | Üres                   |
| ****                             | 11     |                             | Nem egész szám         |
| ****                             | 12     |                             | Nem szám               |
| **életkor**                      | 13     | 1-100                       | >100                   |
| ****                             | 14     |                             |  < 1                   |
| ****                             | 15     |                             | Üres                   |
| ****                             | 16     |                             | Nem egész szám         |
| ****                             | 17     |                             | Nem szám               |
| **utolsó orvosi ellenőrzés.év**  | 18     | 1900-2024                   | >2024                  |
| ****                             | 19     | nem szökőév                 | <1900                  |
| ****                             | 20     | szökőév                     | nem szám               |
| ****                             | 21     | század nem szökőév          | üres                   |
| ****                             | 22     | század szökőév              |                        |
| **utolsó orvosi ellenőrzés.hó**  | 23     | 30 napos                    | >= 13                  |
| ****                             | 24     | 31 napos                    | <= 0                   |
| ****                             | 25     | február                     | nem szám               |
| ****                             | 26     | 1-12                        | üres                   |
| **utolsó orvosi ellenőrzés.nap** | 27     | 1-30                        | >= 32                  |
| ****                             | 28     | 1-31                        | <= 0                   |
| ****                             | 29     | 1-28                        | nem szám               |
| ****                             | 30     | 1-29                        | üres                   |
| **utolsó orvosi ellenőrzés**     | 31     | yyyy.mm.dd                  | üres                   |


### BLA
| **Bemenet**                      | **ID** | **Érték**  | **Határérték** | **Eredmény** |
|----------------------------------|--------|------------|----------------|--------------|
| **id**                           | 1      | 1          | 1              | T            |
| ****                             | 2      | 0          | 1              | F            |
| ****                             | 3      | 2          | 1              | T            |
| ****                             | 4      | 2147483648 | 2147483647     | T            |
| **fajta_id**                     | 5      | 1          | 1              | T            |
| ****                             | 6      | 0          | 1              | F            |
| ****                             | 7      | 2          | 1              | T            |
| ****                             | 8      | 2147483648 | 2147483647     | T            |
| **név_id**                       | 9      | 1          | 1              | T            |
| ****                             | 10     | 0          | 1              | F            |
| ****                             | 11     | 2          | 1              | T            |
| ****                             | 12     | 2147483648 | 2147483647     | T            |
| **életkor**                      | 13     | 1          | 1              | T            |
| ****                             | 14     | 0          | 1              | F            |
| ****                             | 15     | 2          | 1              | T            |
| ****                             | 16     | 99         | 100            | T            |
| ****                             | 17     | 100        | 100            | T            |
| ****                             | 18     | 101        | 100            | F            |
| **utolsó orvosi ellenőrzés.év**  | 19     | 1900       | 1900           | T            |
| ****                             | 20     | 1899       | 1900           | F            |
| ****                             | 21     | 1901       | 1900           | T            |
| ****                             | 22     | 2024       | 2024           | T            |
| ****                             | 23     | 2025       | 2024           | F            |
| ****                             | 24     | 2023       | 2024           | T            |
| **utolsó orvosi ellenőrzés.hó**  | 25     | 1          | 1              | T            |
| ****                             | 26     | 0          | 1              | F            |
| ****                             | 27     | 2          | 1              | T            |
| ****                             | 28     | 12         | 12             | T            |
| ****                             | 29     | 11         | 12             | T            |
| ****                             | 30     | 13         | 12             | F            |
| **utolsó orvosi ellenőrzés.nap** | 31     | 1          | 1              | T            |
| ****                             | 32     | 0          | 1              | F            |
| ****                             | 33     | 2          | 1              | T            |
| ****                             | 34     | 31         | 31             | T            |
| ****                             | 35     | 32         | 31             | F            |
| ****                             | 36     | 30         | 31             | T            |

## KutyaFajta.csv
### Mintavétel
| **id** | **név**               | **eredeti név**                     |
|--------|-----------------------|-------------------------------------|
| 1      | Abruzzói juhászkutya  | Cane da pastore Maremmano-Abruzzese |
| 2      | Afgán agár            | Afghan Hound                        |
| 191    | Kanadai eszkimó kutya | Canadian Eskimo Dog                 |
| 192    | Kanári-szigeteki kopó | Podenco Canario                     |
| 420    | Whippet               | Whippet                             |
| 421    | Yorkshire terrier     | Yorkshire Terrier                   |

### ECP
| **Bemenet**     | **ID** | **Érvényes (VECP)** | **Érvénytelen (IECP)** |
|-----------------|--------|---------------------|------------------------|
| **ID**          | 1      | >= 1                | <1                     |
| ****            | 2      |                     | Üres                   |
| ****            | 3      |                     | Nem egész szám         |
| ****            | 4      |                     | Nem szám               |
| **Név**         | 5      | ABC Betüi           | Üres                   |
| ****            | 6      |                     | Nem betű               |
| **Eredeti név** | 7      | ABC Betüi           | Üres                   |
| ****            | 8      |                     | Nem betű               |

### BLA
| **Bemenet** | **ID** | **Érték**  | **Határérték** | **Eredmény** |
|-------------|--------|------------|----------------|--------------|
| **ID**      | 1      | 1          | 1              | T            |
| ****        | 2      | 0          | 1              | F            |
| ****        | 3      | 2          | 1              | T            |
| ****        | 4      | 2147483648 | 2147483647     | T            |





https://cloudconvert.com/
https://passed.hu/2021/blog-cikkek/teszttervezesi_technikak_1
https://tabletomarkdown.com/convert-spreadsheet-to-markdown/