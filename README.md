# EasyPrototypingNET5
Developer Library for NET (for Core 5)

Diese Bibliothek soll verschiedene Aspekte zur Entwicklung von C# Applikationen unter Microsoft NET (5.0) abdecken. 
Meine bereits vorhandene Microsoft Framework 4.8 Bibliothek wir Stück für Stück soweit es Sinn macht nach aktuelle Microsoft NET (5.0) migriert.

## Typ Extension Methoden
### Extension Methoden und Fluent-Design
Extension Methoden können hilfreich aber auch problematisch sein. So wird häufig kritisiert das Extension Methoden die Intellisense vom Editor ausbremst, oder auch 
zu einem Typ mehr Extension Methoden angezeigt werden, als es tatsächlich Sinn macht. Ein weiterer Punkt ist auch, das erstmal nicht festzustellen ist woher eine Extension kommt. 
Hier habe ich versucht eine alternative Nutzung der Extension zu finden.

### Bekannte Verwendung von Extension
```
bool input = true;
string resut = input.ToYesNoString();
```
Beim Datentyp bool können das noch relative wenig Einträge in der Intellisense sein, beim Typ String kann das schon ganz anderst aussehen.

### Alternative Verwendung von Extension
```
bool input = true;
string resut = input.This().ToYesNoString();
```
Hier erfolgt die Auslistung der Extension erst nach dem ```.This()```.

| Typ Extension for       | Description                                                                                                                                                                                                         |
|-------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Bool                    | Extension Methodes of Typ bool                                                                                                                                                                                      |


