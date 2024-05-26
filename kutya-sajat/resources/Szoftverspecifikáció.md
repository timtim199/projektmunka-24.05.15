# Állatorvosi Nyilvántartó Rendszer - Szoftverspecifikáció

---

## Tartalomjegyzék

- [Állatorvosi Nyilvántartó Rendszer - Szoftverspecifikáció](#állatorvosi-nyilvántartó-rendszer---szoftverspecifikáció)
  - [Tartalomjegyzék](#tartalomjegyzék)
  - [1. Bevezetés](#1-bevezetés)
    - [1.1 Célkitűzés](#11-célkitűzés)
    - [1.2 Célcsoport](#12-célcsoport)
  - [2. Rendszeráttekintés](#2-rendszeráttekintés)
    - [2.1 Rendszerkomponensek](#21-rendszerkomponensek)
    - [2.2 Fő Funkciók](#22-fő-funkciók)
  - [3. Funkcionális Követelmények](#3-funkcionális-követelmények)
    - [3.1 Állatok Adatainak Nyilvántartása](#31-állatok-adatainak-nyilvántartása)
    - [3.2 Kórlapok Kezelése](#32-kórlapok-kezelése)
    - [3.3 Gazdák Adatainak Kezelése](#33-gazdák-adatainak-kezelése)
    - [3.4 Dashboardok](#34-dashboardok)
  - [4. Nem-Funkcionális Követelmények](#4-nem-funkcionális-követelmények)
    - [4.1 Teljesítmény](#41-teljesítmény)
    - [4.2 Megbízhatóság](#42-megbízhatóság)
    - [4.3 Felhasználhatóság](#43-felhasználhatóság)
    - [4.4 Skalázhatóság](#44-skalázhatóság)
  - [5. Felhasználói Felület Tervezés](#5-felhasználói-felület-tervezés)
    - [5.1 WPF Dashboard](#51-wpf-dashboard)
    - [5.2 Web Dashboard](#52-web-dashboard)

---

## 1. Bevezetés

### 1.1 Célkitűzés
Az állatorvosi nyilvántartó rendszer célja, hogy lehetőséget biztosítson az állatorvosoknak és asszisztenseknek az állatok adatainak, kórlapjainak és a gazdák személyigazolvány számának kezelésére. A rendszernek kétféle dashboardja lesz: egy WPF alapú asztali alkalmazás és egy web alapú alkalmazás. A backend ASP.NET alapú lesz, hitelesítés és felhasználói fiókok kezelése nélkül.

### 1.2 Célcsoport
Az alkalmazás célcsoportja az állatorvosok és állatorvosi asszisztensek.

---

## 2. Rendszeráttekintés

### 2.1 Rendszerkomponensek

1. **Backend**: ASP.NET alapú szerver, amely az adatokat kezeli és kiszolgálja a klienseknek.
2. **Desktop Dashboard**: WPF alapú asztali alkalmazás.
3. **Web Dashboard**: Webes felület a böngészőben történő használatra.
4. **Adatbázis**: SQLite adatbázis az adatok tárolására.

### 2.2 Fő Funkciók

- Állatok adatainak nyilvántartása
- Kórlapok kezelése
- Gazdák személyigazolvány számának kezelése
- Dashboardok az adatok kezelésére

---

## 3. Funkcionális Követelmények

### 3.1 Állatok Adatainak Nyilvántartása
- Új állat adatainak rögzítése
- Állatok adatainak szerkesztése
- Állatok adatainak törlése
- Állatok adatainak megtekintése

### 3.2 Kórlapok Kezelése
- Új kórlap létrehozása
- Kórlapok szerkesztése
- Kórlapok törlése
- Kórlapok megtekintése

### 3.3 Gazdák Adatainak Kezelése
- Gazdák személyigazolvány számának rögzítése
- Gazdák adatainak szerkesztése
- Gazdák adatainak törlése
- Gazdák adatainak megtekintése

### 3.4 Dashboardok
- Adatok megjelenítése táblázatos formában
- Keresési és szűrési funkciók

---

## 4. Nem-Funkcionális Követelmények

### 4.1 Teljesítmény
- A rendszernek képesnek kell lennie gyorsan és megbízhatóan kezelni az adatokat.
- Az adatlekéréseknek és mentéseknek 2 másodpercen belül kell megtörténniük.

### 4.2 Megbízhatóság
- A rendszernek magas rendelkezésre állást kell biztosítania.
- Adatvesztés elkerülése érdekében rendszeres biztonsági mentéseket kell végezni.

### 4.3 Felhasználhatóság
- A felhasználói felületeknek könnyen érthetőnek és kezelhetőnek kell lenniük.
- Rendszeres felhasználói tesztek és visszajelzések alapján történő fejlesztés.

### 4.4 Skalázhatóság
- A rendszernek képesnek kell lennie a növekvő adat- és felhasználói terhelés kezelésére.

---


## 5. Felhasználói Felület Tervezés

### 5.1 WPF Dashboard

- **Főképernyő**:
  - Navigációs menü (Állatok, Kórlapok, Tulajdonosok)
  - Adattáblák megjelenítése
  - Műveletek gombok (Új, Szerkesztés, Törlés)

- **Adatlapok**:
  - Formok az adatok bevitelére és szerkesztésére
  - Mentés és vissza gombok

### 5.2 Web Dashboard

- **Főképernyő**:
  - Navigációs menü (Állatok, Kórlapok, Tulajdonosok)
  - Adattáblák megjelenítése
  - Műveletek gombok (Új, Szerkesztés, Törlés)

- **Adatlapok**:
  - Formok az adatok bevitelére és szerkesztésére
  - Mentés és vissza gombok

---
