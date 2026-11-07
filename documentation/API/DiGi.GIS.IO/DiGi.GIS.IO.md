#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

## DiGi\.GIS\.IO Namespace
### Classes

<a name='DiGi.GIS.IO.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.GIS.IO.Create.Columns_ExternalComponentsArea()'></a>

## Create\.Columns\_ExternalComponentsArea\(\) Method

Creates the collection of external components area columns \(walls by azimuth sector, flat and tilted roofs by tilt band and sector, floor, and the total\)\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_ExternalComponentsArea();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of 35 [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances in a stable order: 8 walls by direction, flat roof, tilted roof bands by direction, floor, and the total last\.

<a name='DiGi.GIS.IO.Create.Columns_PartyWallArea()'></a>

## Create\.Columns\_PartyWallArea\(\) Method

Creates the collection of party wall area columns: the wall area each building shares with adjacent buildings, by the azimuth sector of the wall it belongs to, and the total \(DiGi\-Organization/DiGi\.GIS\.Analytical\#4\)\.

The external wall area columns of [Columns\_ExternalComponentsArea\(\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Create.Columns_ExternalComponentsArea() 'DiGi\.GIS\.IO\.Create\.Columns\_ExternalComponentsArea\(\)') stay gross - they include the party walls - so the net external wall area of a sector is the external column minus the party column of the same sector.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PartyWallArea();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of 9 [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances in a stable order: 8 sectors in the order of the external wall columns \(north, northeast, east, southeast, south, southwest, west, northwest\), and the total last\.

<a name='DiGi.GIS.IO.Create.Columns_Population(DiGi.Core.Classes.Range_int_)'></a>

## Create\.Columns\_Population\(Range\<int\>\) Method

Creates a collection of demographic municipality population columns across a range of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_Population(DiGi.Core.Classes.Range<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_Population(DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of target years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing municipality population attributes for the specified range of years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_Population(int)'></a>

## Create\.Columns\_Population\(int\) Method

Creates a single\-element collection containing a demographic municipality population column for the specified year\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_Population(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_Population(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target year for the municipality population count\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list containing a single [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instance configured for the specified year\.

<a name='DiGi.GIS.IO.Create.Columns_Population(System.Collections.Generic.IEnumerable_int_)'></a>

## Create\.Columns\_Population\(IEnumerable\<int\>\) Method

Creates a collection of demographic municipality population columns for a sequence of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_Population(System.Collections.Generic.IEnumerable<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_Population(System.Collections.Generic.IEnumerable_int_).years'></a>

`years` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The sequence of target years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing municipality population attributes for the specified years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(DiGi.Core.Classes.Range_int_)'></a>

## Create\.Columns\_PredictionYearBuilt\(Range\<int\>\) Method

Creates the collection of prediction columns \(confidence, centroid coordinates, and dimensions\) across a range of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PredictionYearBuilt(DiGi.Core.Classes.Range<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of target prediction years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the prediction attributes for the specified range of years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(int)'></a>

## Create\.Columns\_PredictionYearBuilt\(int\) Method

Creates the collection of prediction columns \(confidence, centroid coordinates, and dimensions\) for a specified year\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PredictionYearBuilt(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target prediction year\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the prediction attributes for the specified year\.

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(System.Collections.Generic.IEnumerable_int_)'></a>

## Create\.Columns\_PredictionYearBuilt\(IEnumerable\<int\>\) Method

Creates the collection of prediction columns \(confidence, centroid coordinates, and dimensions\) across a collection of years\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_PredictionYearBuilt(System.Collections.Generic.IEnumerable<int>? years);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_PredictionYearBuilt(System.Collections.Generic.IEnumerable_int_).years'></a>

`years` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of target prediction years\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the prediction attributes for the specified years, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(double)'></a>

## Create\.Columns\_RadialRatios\(double\) Method

Creates a collection containing the radial ratio columns \(building coverage ratio and floor area ratio\) for the specified radius\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_RadialRatios(double radius);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The radius in meters\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the radial ratios for the specified radius\.

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(System.Collections.Generic.IEnumerable_double_)'></a>

## Create\.Columns\_RadialRatios\(IEnumerable\<double\>\) Method

Creates a collection of radial ratio columns \(building coverage ratio and floor area ratio\) for a collection of radiuses\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_RadialRatios(System.Collections.Generic.IEnumerable<double>? radiuses);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Columns_RadialRatios(System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses in meters\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the radial ratios for the specified radiuses, or an empty list if null\.

<a name='DiGi.GIS.IO.Create.Columns_SolarRadiation()'></a>

## Create\.Columns\_SolarRadiation\(\) Method

Creates the collection of yearly solar radiation summary columns: the six building totals, then the sixteen per\-direction values in the north, northeast, east, southeast, south, southwest, west, northwest order, irradiation before energy in each sector, then the three weather source and range metadata columns\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> Columns_SolarRadiation();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of 25 [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances in a stable order: 6 building totals, then 8 sectors × \(irradiation, energy\), then weather source ID, weather source type, and radius\.

<a name='DiGi.GIS.IO.Create.Column_ClosingTolerance()'></a>

## Create\.Column\_ClosingTolerance\(\) Method

Creates the closing tolerance column of the external components classification \- the open\-envelope signal written beside the area columns\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_ClosingTolerance();
```

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') whose cell holds the finest tolerance at which the model's external envelope closes, and is null when the envelope closes at no rung of the ladder or the model carries no external components\.

<a name='DiGi.GIS.IO.Create.Column_GridCellCoverage(int,int)'></a>

## Create\.Column\_GridCellCoverage\(int, int\) Method

Creates a column representing normalized grid cell coverage values for a bounding rectangle\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_GridCellCoverage(int widthCount, int heightCount);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_GridCellCoverage(int,int).widthCount'></a>

`widthCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The segment index along the horizontal axis \(0 to 4\)\.

<a name='DiGi.GIS.IO.Create.Column_GridCellCoverage(int,int).heightCount'></a>

`heightCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The segment index along the vertical axis \(0 to 4\)\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the grid location, target type \(float\), category description, and detailed computation details\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string)'></a>

## Create\.Column\_OrthophotomapData\(int, int, string, string\) Method

Creates a column representing comparison data for orthophotomap images taken in two different years\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_OrthophotomapData(int year_1, int year_2, string columnNamePrefix, string columnNameSuffix);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).year_1'></a>

`year_1` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The first year of the orthophotomap comparison\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).year_2'></a>

`year_2` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The second year of the orthophotomap comparison\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).columnNamePrefix'></a>

`columnNamePrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The prefix describing the type of bounding box filling or method used \(e\.g\., "BB", "P", "PO"\)\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapData(int,int,string,string).columnNameSuffix'></a>

`columnNameSuffix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The suffix describing the metric being compared \(e\.g\., "Average Color Similarity", "Hamming Distance"\)\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(float\), category description, and metadata explanation\.

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapImage(int)'></a>

## Create\.Column\_OrthophotomapImage\(int\) Method

Creates a column containing the URL link to the orthophotomap image for a specific year\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_OrthophotomapImage(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_OrthophotomapImage(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The year of the orthophotomap image\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(string\), category description, and details of the image link\.

<a name='DiGi.GIS.IO.Create.Column_Population(int)'></a>

## Create\.Column\_Population\(int\) Method

Creates a column representing demographic municipality population for a specific year\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_Population(int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_Population(int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target year for the municipality population count\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(int\), category description, and metadata explanation\.

<a name='DiGi.GIS.IO.Create.Column_PredictionYearBuit(string,int)'></a>

## Create\.Column\_PredictionYearBuit\(string, int\) Method

Creates a column representing prediction data related to the year a building was built\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_PredictionYearBuit(string columnNamePrefix, int year);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_PredictionYearBuit(string,int).columnNamePrefix'></a>

`columnNamePrefix` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The prefix describing the prediction type \(e\.g\., confidence or bounding box coordinates\)\.

<a name='DiGi.GIS.IO.Create.Column_PredictionYearBuit(string,int).year'></a>

`year` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The target prediction year\.

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')  
A new [DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.extendedcolumn 'DiGi\.Core\.IO\.Table\.Classes\.ExtendedColumn') configured with the generated name, target type \(double\), category description, and description text\.

<a name='DiGi.GIS.IO.Create.Column_RadialBuildingCoverageRatio(double)'></a>

## Create\.Column\_RadialBuildingCoverageRatio\(double\) Method

Creates a column representing radial building coverage ratio for given radius\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_RadialBuildingCoverageRatio(double radius);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_RadialBuildingCoverageRatio(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Radius \[m\]

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

<a name='DiGi.GIS.IO.Create.Column_RadialFloorAreaRatio(double)'></a>

## Create\.Column\_RadialFloorAreaRatio\(double\) Method

Creates a column representing radial floor area ratio for given radius\.

```csharp
public static DiGi.Core.IO.Table.Classes.Column Column_RadialFloorAreaRatio(double radius);
```
#### Parameters

<a name='DiGi.GIS.IO.Create.Column_RadialFloorAreaRatio(double).radius'></a>

`radius` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

Radius \[m\]

#### Returns
[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

<a name='DiGi.GIS.IO.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object)'></a>

## Modify\.SetValue\(this Row, Column, object\) Method

Sets the value of a specific column in a row, performing input value validation first\.

```csharp
public static void SetValue(this DiGi.Core.IO.Table.Classes.Row? row, DiGi.Core.IO.Table.Classes.Column? column, object? value);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object).row'></a>

`row` [DiGi\.Core\.IO\.Table\.Classes\.Row](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.row 'DiGi\.Core\.IO\.Table\.Classes\.Row')

The row in which the value is to be set\.

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object).column'></a>

`column` [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')

The column whose value is to be set\.

<a name='DiGi.GIS.IO.Modify.SetValue(thisDiGi.Core.IO.Table.Classes.Row,DiGi.Core.IO.Table.Classes.Column,object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The new value to set, which will be validated before setting\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string)'></a>

## Modify\.Update\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, IEnumerable\<Building2DYearBuiltPredictions\>, IEnumerable\<OrtoDatasComparison\>, IEnumerable\<AdministrativeAreal2D\>, string\) Method

Updates the table with building data, year built predictions, orthophotomap comparisons, and administrative boundaries\.

```csharp
public static void Update(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions=null, System.Collections.Generic.IEnumerable<DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison>? ortoDatasComparisons=null, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds=null, string? apiBaseUrl=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of year built predictions to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).ortoDatasComparisons'></a>

`ortoDatasComparisons` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.emgu.cv.classes.ortodatascomparison 'DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of orthophotomap data comparisons to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).administrativeAreal2Ds'></a>

`administrativeAreal2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional collection of administrative boundary areas to update\.

<a name='DiGi.GIS.IO.Modify.Update(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_,string).apiBaseUrl'></a>

`apiBaseUrl` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional API base URL to construct orthophotomap links\.

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn)'></a>

## Modify\.UpdateColumn\<TColumn\>\(this Table, TColumn\) Method

Updates an existing column in the table, or adds it if it does not exist\.

```csharp
public static TColumn? UpdateColumn<TColumn>(this DiGi.Core.IO.Table.Classes.Table? table, TColumn column)
    where TColumn : DiGi.Core.IO.Table.Classes.Column;
```
#### Type parameters

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).TColumn'></a>

`TColumn`

The type of the column to update, which must inherit from [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')\.
#### Parameters

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table containing the column\.

<a name='DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).column'></a>

`column` [TColumn](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).TColumn 'DiGi\.GIS\.IO\.Modify\.UpdateColumn\<TColumn\>\(this DiGi\.Core\.IO\.Table\.Classes\.Table, TColumn\)\.TColumn')

The column template or definition to update or add\.

#### Returns
[TColumn](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.UpdateColumn_TColumn_(thisDiGi.Core.IO.Table.Classes.Table,TColumn).TColumn 'DiGi\.GIS\.IO\.Modify\.UpdateColumn\<TColumn\>\(this DiGi\.Core\.IO\.Table\.Classes\.Table, TColumn\)\.TColumn')  
The updated column matching the specified type, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the table or column parameter is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string)'></a>

## Modify\.Update\_Building2D\(this Table, int, IEnumerable\<Building2D\>, string\) Method

Updates the table with building 2D geometric and shape descriptor features for a specific county\.

Adds and writes the identity columns `Reference` and `County Id`; the function and phase columns `Building general function`, `Building specific functions` and `Building Phase`; the shape columns `Storeys`, `Floor area`, `Total area`, `Internal Point X`, `Internal Point Y`, `BoundingBox X`, `BoundingBox Y`, `BoundingBox width`, `BoundingBox height`, `Cardinal direction`, `Azimuth`, `Isoperimetric ratio`, `Thinness ratio`, `Rectangular thinnes ratio`, `Square thinness ratio`, `Convex hull thinness ratio` and `Calculated Building Shape`; the occupancy flags `Is occupied` and `Is residential`; the per-year orthophotomap link columns; and the grid cell coverage columns.

A cell is written only when its value is computable - the areas only when the outline has one, the internal point and the bounding box only when the outline yields them, the shape only when the solver resolves - so an uncomputable value leaves the cell unset rather than storing a placeholder.

Pushed via `TablePostgreSQLConverter.PushAsync`, the upsert - `ON CONFLICT (county_id, reference) DO UPDATE SET col = EXCLUDED.col` - covers every column present on the table, so a cell left unset on a row is written as NULL and overwrites the stored value of an existing row, while a column this method never adds is never touched.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, string? apiBaseUrl=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string).apiBaseUrl'></a>

`apiBaseUrl` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional API base URL to construct orthophotomap links\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision)'></a>

## Modify\.Update\_Building2D\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, string, string, string, AdministrativeSubdivision\) Method

Updates the table with building 2D administrative features for a specific county and optional subdivision, taking the administrative names directly rather than reading them off boundary objects\.

This is the overload to reach for from a caller that already knows the names - the reference path of a subdivision carries them - because the boundary objects the other overload takes hold the outlines as well, and those are never read here. At the top of an ancestor chain that outline is the whole country, so loading one per subdivision is the dominant cost of a country-wide run and buys nothing.

Adds the administrative columns `Subdivision Id`, `County name`, `Municipality name`, `Voivodeship name`, `Subdivision name`, `Subdivision occupancy` and `Settlement type` to the table, and writes each cell only when its value is present.

The columns are added to the table even when a value does not resolve, and pushed via `TablePostgreSQLConverter.PushAsync` the upsert - `ON CONFLICT (county_id, reference) DO UPDATE SET col = EXCLUDED.col` - covers every column present on the table. An unset cell is written as NULL, so a name that does not resolve on a re-run clears the value previously stored on an existing row; only a column never added to the table is left untouched.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, string? countyName, string? municipalityName, string? voivodeshipName, DiGi.GIS.Classes.AdministrativeSubdivision? administrativeSubdivision);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).countyName'></a>

`countyName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional name of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).municipalityName'></a>

`municipalityName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional name of the municipality\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).voivodeshipName'></a>

`voivodeshipName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The optional name of the voivodeship\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,string,string,string,DiGi.GIS.Classes.AdministrativeSubdivision).administrativeSubdivision'></a>

`administrativeSubdivision` [DiGi\.GIS\.Classes\.AdministrativeSubdivision](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativesubdivision 'DiGi\.GIS\.Classes\.AdministrativeSubdivision')

The optional subdivision, read for its name, occupancy and settlement type\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_)'></a>

## Modify\.Update\_Building2D\(this Table, int, Nullable\<int\>, IEnumerable\<Building2D\>, IEnumerable\<AdministrativeAreal2D\>\) Method

Updates the table with building 2D geometric and administrative features for a specific county and optional subdivision\.

Reads only the name of each division and the name, occupancy and type of the first subdivision out of [administrativeAreal2Ds](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).administrativeAreal2Ds 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\(this DiGi\.Core\.IO\.Table\.Classes\.Table, int, System\.Nullable\<int\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2D\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.AdministrativeAreal2D\>\)\.administrativeAreal2Ds'), then hands those to the overload that takes them directly. A caller that already holds the names - the reference path of a subdivision carries them - should call that overload instead and avoid loading the outlines, which are never read here and reach the size of a whole country at the top of the chain. The administrative columns written, and the unset-cell semantics of the push, are those of the overload it delegates to.

```csharp
public static void Update_Building2D(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Nullable<int> subdivisionId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D(thisDiGi.Core.IO.Table.Classes.Table,int,System.Nullable_int_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.AdministrativeAreal2D_).administrativeAreal2Ds'></a>

`administrativeAreal2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of administrative boundary areas\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_)'></a>

## Modify\.Update\_Building2D\_Occupancy\(this Table, int, IEnumerable\<Building2D\>\) Method

Updates the table with building 2D occupancy features for a specific county\.

```csharp
public static void Update_Building2D_Occupancy(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Occupancy(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_)'></a>

## Modify\.Update\_Building2D\_Population\(this Table, int, IEnumerable\<Building2D\>, StatisticalDataCollection, Range\<int\>\) Method

Updates the table with yearly municipality population data for building 2D geometries in a specific county from a statistical data collection\.

```csharp
public static void Update_Building2D_Population(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, DiGi.GIS.Classes.StatisticalDataCollection? statisticalDataCollection, DiGi.Core.Classes.Range<int>? years=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).statisticalDataCollection'></a>

`statisticalDataCollection` [DiGi\.GIS\.Classes\.StatisticalDataCollection](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.statisticaldatacollection 'DiGi\.GIS\.Classes\.StatisticalDataCollection')

The statistical data collection containing the municipality population data\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalDataCollection,DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The optional range of years for the population series, defaulting to 2008\.\.2025\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_)'></a>

## Modify\.Update\_Building2D\_Population\(this Table, int, IEnumerable\<Building2D\>, StatisticalYearlyDoubleData, Range\<int\>\) Method

Updates the table with yearly municipality population data for building 2D geometries in a specific county from a yearly double data series\.

```csharp
public static void Update_Building2D_Population(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, DiGi.GIS.Classes.StatisticalYearlyDoubleData? statisticalYearlyDoubleData, DiGi.Core.Classes.Range<int>? years=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of building 2D geometries\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).statisticalYearlyDoubleData'></a>

`statisticalYearlyDoubleData` [DiGi\.GIS\.Classes\.StatisticalYearlyDoubleData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.statisticalyearlydoubledata 'DiGi\.GIS\.Classes\.StatisticalYearlyDoubleData')

The yearly statistical double data containing municipality population counts\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_Population(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,DiGi.GIS.Classes.StatisticalYearlyDoubleData,DiGi.Core.Classes.Range_int_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The optional range of years for the population series, defaulting to 2008\.\.2025\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_string_)'></a>

## Modify\.Update\_Building2D\_PredictedYearBuilt\(this Table, int, IEnumerable\<string\>\) Method

Clears the `Predicted year built` column of each named building in a specific county, leaving the `User year built` and `Calculated year built` columns as they stood\.

Only the predicted column is carried, so `TablePostgreSQLConverter.PushAsync` writes NULL for it on the named rows while the two other year built columns are untouched - a table pushed without a column does not touch the stored column. A value a matched row already held is removed from it, so a stale predicted year cannot survive into the push.

This is the companion to [Update\_Building2D\_YearBuiltPredictions\(this Table, int, IEnumerable&lt;Building2DYearBuiltPredictions&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_) 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\_YearBuiltPredictions\(this DiGi\.Core\.IO\.Table\.Classes\.Table, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions\>\)'): a building the current detector never fired on has its detection columns replaced (DiGi-Organization/DiGi.GIS.YOLO.UI#21), and this removes the predicted year that was derived from the evidence that is now gone (DiGi-Organization/DiGi.GIS.YOLO.UI#28). It is the selective counterpart of [Update\_Building2D\_YearBuilt\(this Table, int, IEnumerable&lt;YearBuiltData&gt;, IEnumerable&lt;string&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_) 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\_YearBuilt\(this DiGi\.Core\.IO\.Table\.Classes\.Table, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.YearBuiltData\>, System\.Collections\.Generic\.IEnumerable\<string\>\)'), which clears all three year built columns together and would also remove a stored user year.

```csharp
public static int Update_Building2D_PredictedYearBuilt(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<string>? references);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_string_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_string_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_PredictedYearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_string_).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The references of the buildings whose predicted year is cleared\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of references emitted \- updated and appended alike\. Zero when nothing was written, so a run can tell a county without named buildings from one it never asked about\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_)'></a>

## Modify\.Update\_Building2D\_YearBuilt\(this Table, int, IEnumerable\<YearBuiltData\>, IEnumerable\<string\>\) Method

Updates the table with the three year built columns \- predicted, user and calculated \- of each building in a specific county\.

A building may hold several stored [DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData') records - the table appends rather than replaces - so the entries of every record carrying the same reference are considered together: each column holds the most frequent year of its kind, the user column counts only exact user years, and the calculated column is the user year when one exists, otherwise the predicted year. All three are derived from the same records in the same call, so they cannot disagree.

Rows already in the table are matched on county identifier and reference; a reference the table does not hold yet is appended. A column a building holds no value for is left unset in its row - which is not "left as it stood" once the table is stored: `TablePostgreSQLConverter.PushAsync` writes NULL for every unset cell of a column the pushed table carries, and the three columns are carried as soon as one building has a value.

Without [references](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_).references 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\_YearBuilt\(this DiGi\.Core\.IO\.Table\.Classes\.Table, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.YearBuiltData\>, System\.Collections\.Generic\.IEnumerable\<string\>\)\.references') a building whose records carry no usable entry at all leaves no row behind, so its stored columns are never touched. With it, every named building gets a row and the three columns are always added, a value its history no longer holds being an unset cell (removed from a row the table already held) - pushing the table then clears it. That is what a recompute after a removal needs; a building data run leaves it out.

```csharp
public static int Update_Building2D_YearBuilt(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.YearBuiltData>? yearBuiltDatas, System.Collections.Generic.IEnumerable<string>? references=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_).yearBuiltDatas'></a>

`yearBuiltDatas` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of stored year built data to derive the columns from\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The references of the buildings to emit a row for whatever their history holds, or `null` to emit only the buildings with at least one value\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The number of rows given at least one of the three values \- updated and appended alike\. Rows emitted for [references](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.YearBuiltData_,System.Collections.Generic.IEnumerable_string_).references 'DiGi\.GIS\.IO\.Modify\.Update\_Building2D\_YearBuilt\(this DiGi\.Core\.IO\.Table\.Classes\.Table, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.YearBuiltData\>, System\.Collections\.Generic\.IEnumerable\<string\>\)\.references') with no value are not counted\. Zero when nothing was written, so a run can tell a county without stored entries from one it never asked about\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_)'></a>

## Modify\.Update\_Building2D\_YearBuiltPredictions\(this Table, int, IEnumerable\<Building2DYearBuiltPredictions\>\) Method

Updates the table with year\-built predictions for structures in a specific county\.

```csharp
public static void Update_Building2D_YearBuiltPredictions(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2DYearBuiltPredictions>? building2DYearBuiltPredictions);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_Building2D_YearBuiltPredictions(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2DYearBuiltPredictions_).building2DYearBuiltPredictions'></a>

`building2DYearBuiltPredictions` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2dyearbuiltpredictions 'DiGi\.GIS\.Classes\.Building2DYearBuiltPredictions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of year\-built predictions\.

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_)'></a>

## Modify\.Update\_OrtoDatasComparison\(this Table, int, IEnumerable\<OrtoDatasComparison\>\) Method

Updates the table with orthophotomap comparison data for structures in a specific county\.

```csharp
public static void Update_OrtoDatasComparison(this DiGi.Core.IO.Table.Classes.Table? table, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison>? ortoDatasComparisons);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county\.

<a name='DiGi.GIS.IO.Modify.Update_OrtoDatasComparison(thisDiGi.Core.IO.Table.Classes.Table,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Emgu.CV.Classes.OrtoDatasComparison_).ortoDatasComparisons'></a>

`ortoDatasComparisons` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.emgu.cv.classes.ortodatascomparison 'DiGi\.GIS\.Emgu\.CV\.Classes\.OrtoDatasComparison')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of orthophotomap data comparisons\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double)'></a>

## Modify\.Update\_RadialRatios\(this Table, IEnumerable\<double\>, int, Building2D, IEnumerable\<Building2D\>, double\) Method

Updates the table with radial ratios \(Radial Building Coverage Ratio and Radial Floor Area Ratio\) for a specific county and building 2D geometry\.

```csharp
public static void Update_RadialRatios(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IEnumerable<double> radiuses, int countyId, DiGi.GIS.Classes.Building2D? building2D, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The list of radiuses to consider\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ID of the county\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2D'></a>

`building2D` [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')

The building 2D\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The list of building 2Ds\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,DiGi.GIS.Classes.Building2D,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The tolerance for distance calculations\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double)'></a>

## Modify\.Update\_RadialRatios\(this Table, IEnumerable\<double\>, int, IEnumerable\<Building2D\>, IEnumerable\<Building2D\>, double\) Method

Updates the table with radial ratios \(Radial Building Coverage Ratio and Radial Floor Area Ratio\) for a whole collection of buildings at once\.

This is the overload to reach for when more than one building is measured against the same surroundings. The table row index, the ratio columns, each neighbour's outline area and bounding box, and a grid index over the neighbours are all built once for the collection rather than once per building - the single-building overload delegates here with a collection of one, so a per-building loop over it repeats all of that work for every building and rescans the whole table each time.

[building2Ds\_Neighbour](DiGi.GIS.IO.md#DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds_Neighbour 'DiGi\.GIS\.IO\.Modify\.Update\_RadialRatios\(this DiGi\.Core\.IO\.Table\.Classes\.Table, System\.Collections\.Generic\.IEnumerable\<double\>, int, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2D\>, System\.Collections\.Generic\.IEnumerable\<DiGi\.GIS\.Classes\.Building2D\>, double\)\.building2Ds\_Neighbour') is the surroundings, not the subjects: it must already cover every building within the largest radius of every subject, including buildings outside the subjects' own area, and it normally contains the subjects themselves as well - a building counts towards its own ratios.

```csharp
public static void Update_RadialRatios(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IEnumerable<double> radiuses, int countyId, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds, System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.Building2D>? building2Ds_Neighbour, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to update\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The list of radiuses to consider\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ID of the county\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds'></a>

`building2Ds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The buildings the ratios are measured for and written against\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).building2Ds_Neighbour'></a>

`building2Ds_Neighbour` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The surrounding buildings the ratios are measured over\.

<a name='DiGi.GIS.IO.Modify.Update_RadialRatios(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_double_,int,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,System.Collections.Generic.IEnumerable_DiGi.GIS.Classes.Building2D_,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The tolerance for distance calculations\.

<a name='DiGi.GIS.IO.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Fields

<a name='DiGi.GIS.IO.Query.sourceIdKeys'></a>

## Query\.sourceIdKeys Field

The source columns tried, in order, when deriving a source identifier from a row\.

```csharp
private static readonly string[] sourceIdKeys;
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')
### Methods

<a name='DiGi.GIS.IO.Query.AttributeValue(object)'></a>

## Query\.AttributeValue\(object\) Method

Converts a raw column value read from a source file into a [System\.Text\.Json\.Nodes\.JsonNode](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode 'System\.Text\.Json\.Nodes\.JsonNode') for the attribute bag, preserving the value's JSON type\.

Numeric columns stay numbers and boolean columns stay booleans so a round trip through the serializer compares equal; binary columns become base64 text because JSON has no byte type. Text is kept as text even when it looks numeric - identifiers such as 32-hex GERS ids would otherwise be corrupted by a numeric parse.

```csharp
private static System.Text.Json.Nodes.JsonNode? AttributeValue(object? value);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.AttributeValue(object).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The raw column value, or null for a null column\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonNode](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode 'System\.Text\.Json\.Nodes\.JsonNode')  
The value as a [System\.Text\.Json\.Nodes\.JsonNode](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonnode 'System\.Text\.Json\.Nodes\.JsonNode'), or null when the column is null\.

<a name='DiGi.GIS.IO.Query.DefaultOnlyColumnNames(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.DefaultOnlyColumnNames\(this Table\) Method

Names the columns of a table that carry the same value in every row\.

Written as the acceptance check on an assembled training table. A feature column that never varies teaches the regressor nothing, and on this pipeline it has a specific and expensive cause: the detection and population columns are created by runs rather than by code, so a table assembled before those runs is a full looking file in which 108 of 172 features are the default. LightGbm fits it without complaining and the resulting metrics look ordinary.

See [UnpopulatedColumnNames\(this Table, IEnumerable&lt;Column&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.UnpopulatedColumnNames(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Column_) 'DiGi\.GIS\.IO\.Query\.UnpopulatedColumnNames\(this DiGi\.Core\.IO\.Table\.Classes\.Table, System\.Collections\.Generic\.IEnumerable\<DiGi\.Core\.IO\.Table\.Classes\.Column\>\)') for the neighbouring question on the inference side - not which columns never vary, but which carry nothing at all.

A hit is not automatically a defect - a single county genuinely shares one `County name`, and a rarely populated feature can be constant on a small sample. It is a list to explain, not a list to fail on blindly.

```csharp
public static System.Collections.Generic.List<string> DefaultOnlyColumnNames(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.DefaultOnlyColumnNames(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to inspect\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The names of the columns that never vary, in column order\. Empty when every column varies, or when the table has fewer than two rows to compare\.

<a name='DiGi.GIS.IO.Query.FirstDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.Classes.Range_int_,short)'></a>

## Query\.FirstDetectionYears\(this Table, Range\<int\>, short\) Method

Computes the regressor\-free "first detection year" baseline, one entry per row\.

For each row, the first year of the range whose `Prediction Confidence {year}` value is present and greater than zero - the first year the detector saw the building. A row whose confidence values are all absent or zero falls back to `year_Default`.

This is the detector-only acceptance baseline of the YOLO retrain (DiGi-Organization/DiGi.GIS.YOLO.UI#12): on the 2025-05-27 table it scores MAE 0.434 (OrtoBuildingDetectionModel.provenance.md), the bar a retrained detector has to clear. The regressor evaluation and the detector evaluation both compute it from the same columns, so the rule lives here where both can reach it.

The result aligns with the rows by index, so a caller that wants a dictionary zips it with the reference column.

```csharp
public static System.Collections.Generic.List<short> FirstDetectionYears(this DiGi.Core.IO.Table.Classes.Table? table, DiGi.Core.Classes.Range<int>? years=null, short year_Default=2008);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.FirstDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.Classes.Range_int_,short).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table carrying the per\-year `Prediction Confidence` columns, or null\.

<a name='DiGi.GIS.IO.Query.FirstDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.Classes.Range_int_,short).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The years to scan, in row order\. Defaults to 2008\.\.2025, the same default as [YearBuiltPredictionFeatureGroups\(Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionFeatureGroups(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionFeatureGroups\(DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)')\.

<a name='DiGi.GIS.IO.Query.FirstDetectionYears(thisDiGi.Core.IO.Table.Classes.Table,DiGi.Core.Classes.Range_int_,short).year_Default'></a>

`year_Default` [System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')

The year reported for a row whose confidence values are all absent or zero\. Defaults to 2008\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
One entry per row, in row order: the first detection year of each row\. Empty when the table is null or holds no rows\.

<a name='DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_CsvAsync\(string, BuildingDataset, BoundingBox2D, CancellationToken\) Method

Streams building footprints from a delimited CSV attribute table \(GHS\-OBAT\) as an asynchronous sequence, returning each footprint in EPSG:4326\.

The file is read line by line through [DiGi\.Core\.IO\.DelimitedData\.Classes\.DelimitedDataReader](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.delimiteddata.classes.delimiteddatareader 'DiGi\.Core\.IO\.DelimitedData\.Classes\.DelimitedDataReader') so a country table is never materialised, and every cell stays exactly the text the source published - inferring numbers would corrupt identifiers such as 32-hex GERS ids that happen to contain only digits. The geometry is a point built from the longitude and latitude columns (accepting `lon`/`latitude` and `lat`/`longitude` spellings), which is what lets [boundingBox](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox 'DiGi\.GIS\.IO\.Query\.Footprints\_CsvAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.boundingBox') filter before provenance is derived.

A row whose value count disagrees with the header, or whose coordinates do not parse, fails loudly with its row index rather than silently shifting every following column.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint>? Footprints_CsvAsync(string? path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CSV file, or null or whitespace to return null\.

<a name='DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds; GhsObat\.

<a name='DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in EPSG:4326, that footprints must intersect\.

<a name='DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence, or null when [path](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path 'DiGi\.GIS\.IO\.Query\.Footprints\_CsvAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.path') is null or whitespace\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [buildingDataset](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_CsvAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset 'DiGi\.GIS\.IO\.Query\.Footprints\_CsvAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.buildingDataset') is not GhsObat\.

[System\.IO\.InvalidDataException](https://learn.microsoft.com/en-us/dotnet/api/system.io.invaliddataexception 'System\.IO\.InvalidDataException')  
Thrown when the file is empty, lacks a longitude/latitude column pair, or holds a malformed row\.

<a name='DiGi.GIS.IO.Query.Footprints_Csv_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_Csv\_Iterator\(string, BuildingDataset, BoundingBox2D, CancellationToken\) Method

Walks a CSV attribute table row by row, yielding one [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') per row\.

```csharp
private static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint> Footprints_Csv_Iterator(string path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_Csv_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the CSV file\.

<a name='DiGi.GIS.IO.Query.Footprints_Csv_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds\.

<a name='DiGi.GIS.IO.Query.Footprints_Csv_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in EPSG:4326\.

<a name='DiGi.GIS.IO.Query.Footprints_Csv_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_GeoJsonSequenceAsync\(string, BuildingDataset, string, BoundingBox2D, CancellationToken\) Method

Streams building footprints from a Microsoft Global ML Building Footprints line\-delimited GeoJSON file \(plain or gzip\) as an asynchronous sequence, returning each footprint in EPSG:4326\.

gzip is detected from the file's magic bytes rather than its extension, so a renamed or mislabelled chunk still reads. The features carry no identifier of their own, so the source id is synthesized as `quadkey:index` over the zero-based feature index - a value that is stable for a given published chunk. The quadkey the chunk was fetched under becomes provenance together with any `capture` properties.

Geometry is built from the JSON coordinates directly instead of through NetTopologySuite.IO.GeoJSON, keeping Newtonsoft out of every host that references this assembly.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint>? Footprints_GeoJsonSequenceAsync(string? path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, string quadkey, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the GeoJSON sequence file, or null or whitespace to return null\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds; Microsoft\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).quadkey'></a>

`quadkey` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The quadkey the chunk was fetched under, required to synthesize source identifiers and provenance\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in EPSG:4326, that footprints must intersect\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence, or null when [path](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoJsonSequenceAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, string, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.path') is null or whitespace\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [buildingDataset](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoJsonSequenceAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, string, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.buildingDataset') is not Microsoft, or when [quadkey](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoJsonSequenceAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).quadkey 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoJsonSequenceAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, string, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.quadkey') is null or whitespace\.

[System\.IO\.InvalidDataException](https://learn.microsoft.com/en-us/dotnet/api/system.io.invaliddataexception 'System\.IO\.InvalidDataException')  
Thrown when a line is not a feature, carries an unsupported geometry type, or holds malformed coordinates\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequence_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_GeoJsonSequence\_Iterator\(string, BuildingDataset, string, BoundingBox2D, CancellationToken\) Method

Walks a line\-delimited GeoJSON file line by line, yielding one [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') per feature\.

```csharp
private static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint> Footprints_GeoJsonSequence_Iterator(string path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, string quadkey, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequence_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the GeoJSON sequence file\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequence_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequence_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).quadkey'></a>

`quadkey` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The quadkey the chunk was fetched under\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequence_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in EPSG:4326\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoJsonSequence_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,string,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_GeoPackageAsync\(string, BuildingDataset, BoundingBox2D, string, CancellationToken\) Method

Streams building footprints from a GeoPackage file \(EUBUCCO, DBSM, GHS\-OBAT centroids\) as an asynchronous sequence, returning each footprint in the file's own coordinate reference system\.

The file is opened read-only and walked row by row: no country file is ever materialised, so a multi-gigabyte EUBUCCO release costs one row of memory at a time. The spatial reference identifier comes from `gpkg_geometry_columns` joined to `gpkg_spatial_ref_sys` (an EPSG organisation code wins over the local srs_id) and is validated against the supported set at enumeration start, so an unexpected reference system fails loudly before the first row is interpreted.

Every column except the geometry blob becomes an entry in [Attributes](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.Attributes 'DiGi\.GIS\.IO\.Classes\.Footprint\.Attributes'), provenance and the EUBUCCO licence exception are derived per row, and [boundingBox](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).boundingBox 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoPackageAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, string, System\.Threading\.CancellationToken\)\.boundingBox') - expressed in the file's coordinate reference system - filters on the decoded geometry envelope.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint>? Footprints_GeoPackageAsync(string? path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox=null, string? tableName=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the GeoPackage file, or null or whitespace to return null\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds; Eubucco, Dbsm or GhsObat\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in the file's coordinate reference system, that footprints must intersect\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).tableName'></a>

`tableName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The geometry table to read; required only when the file registers more than one\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence, or null when [path](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).path 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoPackageAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, string, System\.Threading\.CancellationToken\)\.path') is null or whitespace\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [buildingDataset](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoPackageAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).buildingDataset 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoPackageAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, string, System\.Threading\.CancellationToken\)\.buildingDataset') is not a GeoPackage dataset, or when the file registers several geometry tables and no table name was given\.

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Thrown at enumeration start when the file declares an SRID other than 4326 or 3035\.

[System\.IO\.InvalidDataException](https://learn.microsoft.com/en-us/dotnet/api/system.io.invaliddataexception 'System\.IO\.InvalidDataException')  
Thrown when the file has no geometry table, the registered geometry column is missing, or a row carries no geometry\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackage_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_GeoPackage\_Iterator\(string, BuildingDataset, BoundingBox2D, string, CancellationToken\) Method

Walks a GeoPackage geometry table row by row, yielding one [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') per row\.

```csharp
private static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint> Footprints_GeoPackage_Iterator(string path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox, string? tableName, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackage_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the GeoPackage file\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackage_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackage_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in the file's coordinate reference system\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackage_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).tableName'></a>

`tableName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The geometry table to read, or null to use the file's only one\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoPackage_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_GeoParquetAsync\(string, BuildingDataset, BoundingBox2D, CancellationToken\) Method

Streams building footprints from a GeoParquet file \(Overture Buildings\) as an asynchronous sequence, returning each footprint in the file's own coordinate reference system\.

The file is walked one row group at a time and never materialised as a whole. When a bounding box is given and the file carries a `covering.bbox`, the read is pruned with the row group's footer statistics on the covering columns: a group judged disjoint is never opened or decompressed. The row-level filter still runs on the decoded geometry envelope, so a corrupt geometry sitting in a pruned group never gets decoded - and the same file read without a bounding box fails loudly instead of hiding it.

The spatial reference identifier comes from the `geo` metadata (`srs_id`, else the PROJJSON CRS code, else the format default of 4326) and is validated at enumeration start. Every column becomes an entry in [Attributes](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.Attributes 'DiGi\.GIS\.IO\.Classes\.Footprint\.Attributes') except the geometry column and the covering columns, which are derived rather than source data; repeated columns such as Overture's `sources` are grouped back into JSON arrays row by row.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint>? Footprints_GeoParquetAsync(string? path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the GeoParquet file, or null or whitespace to return null\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds; Overture\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in the file's coordinate reference system, that footprints must intersect\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence, or null when [path](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoParquetAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.path') is null or whitespace\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [buildingDataset](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Footprints_GeoParquetAsync(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset 'DiGi\.GIS\.IO\.Query\.Footprints\_GeoParquetAsync\(string, DiGi\.GIS\.IO\.Enums\.BuildingDataset, DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D, System\.Threading\.CancellationToken\)\.buildingDataset') is not Overture\.

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Thrown at enumeration start when the file declares an SRID other than 4326 or 3035\.

[System\.IO\.InvalidDataException](https://learn.microsoft.com/en-us/dotnet/api/system.io.invaliddataexception 'System\.IO\.InvalidDataException')  
Thrown when the file carries no `geo` metadata, declares an unparsable CRS, or has no geometry column\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquet_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken)'></a>

## Query\.Footprints\_GeoParquet\_Iterator\(string, BuildingDataset, BoundingBox2D, CancellationToken\) Method

Walks a GeoParquet file row group by row group, yielding one [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') per row\.

```csharp
private static System.Collections.Generic.IAsyncEnumerable<DiGi.GIS.IO.Classes.Footprint> Footprints_GeoParquet_Iterator(string path, DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, DiGi.Geometry.Planar.Classes.BoundingBox2D? boundingBox, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquet_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the GeoParquet file\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquet_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset the file holds\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquet_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

An optional bounding box, in the file's coordinate reference system\.

<a name='DiGi.GIS.IO.Query.Footprints_GeoParquet_Iterator(string,DiGi.GIS.IO.Enums.BuildingDataset,DiGi.Geometry.Planar.Classes.BoundingBox2D,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Collections\.Generic\.IAsyncEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')[Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1 'System\.Collections\.Generic\.IAsyncEnumerable\`1')  
The streaming sequence\.

<a name='DiGi.GIS.IO.Query.Geometry_Json(System.Text.Json.JsonElement,NetTopologySuite.Geometries.GeometryFactory)'></a>

## Query\.Geometry\_Json\(JsonElement, GeometryFactory\) Method

Builds a NetTopologySuite geometry from a GeoJSON geometry element, so a line\-delimited GeoJSON sequence can be read without pulling the Newtonsoft\-based NetTopologySuite\.IO\.GeoJSON reader into every host that references this assembly\.

Every geometry type the open building datasets use is supported; an unknown type or a malformed position fails loudly with the reason, because a silently dropped or silently reshaped geometry would surface much later as a wrong area.

```csharp
private static NetTopologySuite.Geometries.Geometry Geometry_Json(System.Text.Json.JsonElement geometryElement, NetTopologySuite.Geometries.GeometryFactory geometryFactory);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Geometry_Json(System.Text.Json.JsonElement,NetTopologySuite.Geometries.GeometryFactory).geometryElement'></a>

`geometryElement` [System\.Text\.Json\.JsonElement](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonelement 'System\.Text\.Json\.JsonElement')

The JSON element holding the geometry \(its `type` and `coordinates`, or `geometries` for a collection\)\.

<a name='DiGi.GIS.IO.Query.Geometry_Json(System.Text.Json.JsonElement,NetTopologySuite.Geometries.GeometryFactory).geometryFactory'></a>

`geometryFactory` [NetTopologySuite\.Geometries\.GeometryFactory](https://learn.microsoft.com/en-us/dotnet/api/nettopologysuite.geometries.geometryfactory 'NetTopologySuite\.Geometries\.GeometryFactory')

The factory used to create the geometry\.

#### Returns
[NetTopologySuite\.Geometries\.Geometry](https://learn.microsoft.com/en-us/dotnet/api/nettopologysuite.geometries.geometry 'NetTopologySuite\.Geometries\.Geometry')  
The geometry\.

#### Exceptions

[System\.IO\.InvalidDataException](https://learn.microsoft.com/en-us/dotnet/api/system.io.invaliddataexception 'System\.IO\.InvalidDataException')  
Thrown when the element is not a geometry, carries an unsupported type, or holds malformed coordinates\.

<a name='DiGi.GIS.IO.Query.Holdout(string,int)'></a>

## Query\.Holdout\(string, int\) Method

Decides whether one key belongs to the Year Built holdout, by hashing the key rather than by shuffling\.

A seeded shuffle is only reproducible inside one runtime: the same seed gives different orders in .NET and in Python, and the framework is free to change its generator between versions. Hashing the key makes membership a property of the row, so the same holdout comes back on any machine, in any language, in any order, and two runs months apart stay comparable.

The hash is FNV-1a over the UTF-8 bytes, written out here rather than taken from `string.GetHashCode`, which is randomised per process and would put the same building in a different half on every run.

Pass the building reference to hold out roughly one row in five. Pass the subdivision identifier to hold out whole subdivisions instead, so no subdivision spans training and holdout - that is the control for a model memorising neighbourhoods rather than reading the imagery.

This is the holdout both the year built regressor (DiGi.GIS.ML) and the YOLO dataset builder (DiGi.GIS.YOLO.UI) carve, so it lives in DiGi.GIS.IO where both can reach it without dragging ML.NET into the detector side.

```csharp
public static bool Holdout(string? key, int denominator=5);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Holdout(string,int).key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The row key \- a building reference or a subdivision identifier\.

<a name='DiGi.GIS.IO.Query.Holdout(string,int).denominator'></a>

`denominator` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

One row in this many joins the holdout\. 5 gives a 20 percent holdout\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the key belongs to the holdout, false for a null or empty key\.

<a name='DiGi.GIS.IO.Query.Holdouts(thisSystem.Collections.Generic.IEnumerable_string_,int)'></a>

## Query\.Holdouts\(this IEnumerable\<string\>, int\) Method

Decides Year Built holdout membership for every key, in row order\.

Delegates to [Holdout\(string, int\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.Holdout(string,int) 'DiGi\.GIS\.IO\.Query\.Holdout\(string, int\)') per key so the two cannot disagree. A null or empty key is simply not in the holdout, so the result always carries one entry per key, and null input gives an empty list rather than throwing.

```csharp
public static System.Collections.Generic.List<bool> Holdouts(this System.Collections.Generic.IEnumerable<string?>? keys, int denominator=5);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Holdouts(thisSystem.Collections.Generic.IEnumerable_string_,int).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The key of each row, in row order \- building references, or subdivision identifiers for the grouped carve\.

<a name='DiGi.GIS.IO.Query.Holdouts(thisSystem.Collections.Generic.IEnumerable_string_,int).denominator'></a>

`denominator` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

One row in this many joins the holdout\. 5 gives a 20 percent holdout\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
True for each row that belongs to the holdout, in row order\. Empty when the input is null\.

<a name='DiGi.GIS.IO.Query.LicenceException(string)'></a>

## Query\.LicenceException\(string\) Method

Returns the regional licence exception that applies to an EUBUCCO geometry\_source value, or null when the source carries none\.

The two flagged sources are Prague (CC-BY-SA, share-alike) and Abruzzo (CC-BY-NC, non-commercial); every other source stays under the plain ODbL licence. The lookup is a comparison rather than a filter so a flagged row travels on with its exception attached instead of being dropped from a read.

```csharp
private static string? LicenceException(string? geometrySource);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.LicenceException(string).geometrySource'></a>

`geometrySource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The geometry\_source column value, or null\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The licence exception string, or null when no exception applies\.

<a name='DiGi.GIS.IO.Query.Metadata_GeoParquet(string,Parquet.ParquetReader)'></a>

## Query\.Metadata\_GeoParquet\(string, ParquetReader\) Method

Parses the `geo` metadata of a GeoParquet file into the facts a read needs: the spatial reference identifier, the primary geometry column and the covering columns\.

The identifier comes from `srs_id` when the writer supplies one, otherwise from the PROJJSON `crs.id` code, and a missing or null `crs` means the default of the format, CRS84 (EPSG:4326). A CRS that is present but carries no parseable identifier fails loudly: an unknown reference system can be neither validated against the supported set nor labelled honestly.

Covering columns are resolved against the schema here as well, so a covering path that names a column absent from the file degrades to a full scan rather than to a crash mid-read.

```csharp
private static DiGi.GIS.IO.Query.GeoParquetMetadata Metadata_GeoParquet(string path, Parquet.ParquetReader parquetReader);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Metadata_GeoParquet(string,Parquet.ParquetReader).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the file being read, used in exception messages\.

<a name='DiGi.GIS.IO.Query.Metadata_GeoParquet(string,Parquet.ParquetReader).parquetReader'></a>

`parquetReader` [Parquet\.ParquetReader](https://learn.microsoft.com/en-us/dotnet/api/parquet.parquetreader 'Parquet\.ParquetReader')

The open reader supplying the custom metadata and schema\.

#### Returns
[GeoParquetMetadata](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.GeoParquetMetadata 'DiGi\.GIS\.IO\.Query\.GeoParquetMetadata')  
The parsed metadata\.

#### Exceptions

[System\.IO\.InvalidDataException](https://learn.microsoft.com/en-us/dotnet/api/system.io.invaliddataexception 'System\.IO\.InvalidDataException')  
Thrown when the file has no `geo` metadata, or a CRS that cannot be reduced to an identifier\.

<a name='DiGi.GIS.IO.Query.Provenance(DiGi.GIS.IO.Enums.BuildingDataset,System.Text.Json.Nodes.JsonObject,string)'></a>

## Query\.Provenance\(BuildingDataset, JsonObject, string\) Method

Builds the per\-object provenance for a row from its attribute bag, in the shape the building\_dataset release register expects \(DiGi\-Organization/DiGi\.GIS\.PostgreSQL\#125\)\.

Each dataset states its geometry origin differently: EUBUCCO carries every column whose name contains `_source`; DBSM carries the `source` column plus the `eub_json` link blob, parsed to an object when it parses and kept as raw text otherwise; GHS-OBAT links through the Overture identifier, exposed under the single key `overture_id` whether the source column is named `overture_id` or `id`; Overture carries `id` and the full `sources` array; Microsoft features carry no origin at all, so the quadkey the file was fetched under plus any `capture` properties stand in as provenance.

The attribute bag keeps every column as well: provenance is an additional view, not a move, so no consumer loses a column by this method running.

```csharp
private static System.Text.Json.Nodes.JsonObject? Provenance(DiGi.GIS.IO.Enums.BuildingDataset buildingDataset, System.Text.Json.Nodes.JsonObject? attributes, string? quadkey);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Provenance(DiGi.GIS.IO.Enums.BuildingDataset,System.Text.Json.Nodes.JsonObject,string).buildingDataset'></a>

`buildingDataset` [BuildingDataset](DiGi.GIS.IO.Enums.md#DiGi.GIS.IO.Enums.BuildingDataset 'DiGi\.GIS\.IO\.Enums\.BuildingDataset')

The dataset being read\.

<a name='DiGi.GIS.IO.Query.Provenance(DiGi.GIS.IO.Enums.BuildingDataset,System.Text.Json.Nodes.JsonObject,string).attributes'></a>

`attributes` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The attribute bag built from the source row, or null\.

<a name='DiGi.GIS.IO.Query.Provenance(DiGi.GIS.IO.Enums.BuildingDataset,System.Text.Json.Nodes.JsonObject,string).quadkey'></a>

`quadkey` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The quadkey a Microsoft line\-delimited GeoJSON file was fetched under; used only for that dataset\.

#### Returns
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')  
The provenance object, or null when the row carries nothing provenance\-worthy\.

<a name='DiGi.GIS.IO.Query.Quadkey(string)'></a>

## Query\.Quadkey\(string\) Method

Reads the quadkey a Microsoft Global ML Building Footprints chunk was published under from its path \- the `quadkey=<digits>` directory segment of Microsoft's own layout \(`…/RegionName=Poland/quadkey=120213101/part-….csv.gz`\) \- so a run over several chunks can identify each file by its own quadkey \(DiGi\-Organization/DiGi\.GIS\.PostgreSQL\#132\)\.

Only a directory segment counts, never the file name, and the innermost one wins when a path nests several. A segment whose value is not made of the quadkey digits 0-3 is not a quadkey and yields null rather than a wrong source identity.

```csharp
public static string? Quadkey(string? path);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.Quadkey(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file path, with Windows or POSIX separators, or null\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The quadkey, or null when the path carries no valid `quadkey=` directory segment\.

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D)'></a>

## Query\.RowGroup\_InRange\(ParquetRowGroupReader, DataField, DataField, DataField, DataField, BoundingBox2D\) Method

Decides whether a Parquet row group can hold rows inside a bounding box, using only the row group's min/max statistics on the covering columns\.

This is the pruning half of a spatial read: the statistics travel in the file footer, so the decision costs four footer lookups and a disjointness test, and a group judged disjoint is never opened or decompressed. A group whose statistics are missing or unreadable counts as intersecting, because the failure mode of pruning must always be extra work rather than a dropped row.

```csharp
private static bool RowGroup_InRange(Parquet.ParquetRowGroupReader parquetRowGroupReader, Parquet.Schema.DataField? coveringMinX, Parquet.Schema.DataField? coveringMaxX, Parquet.Schema.DataField? coveringMinY, Parquet.Schema.DataField? coveringMaxY, DiGi.Geometry.Planar.Classes.BoundingBox2D boundingBox);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D).parquetRowGroupReader'></a>

`parquetRowGroupReader` [Parquet\.ParquetRowGroupReader](https://learn.microsoft.com/en-us/dotnet/api/parquet.parquetrowgroupreader 'Parquet\.ParquetRowGroupReader')

The open row group reader supplying statistics\.

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D).coveringMinX'></a>

`coveringMinX` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's minimum X, or null\.

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D).coveringMaxX'></a>

`coveringMaxX` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's maximum X, or null\.

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D).coveringMinY'></a>

`coveringMinY` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's minimum Y, or null\.

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D).coveringMaxY'></a>

`coveringMaxY` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's maximum Y, or null\.

<a name='DiGi.GIS.IO.Query.RowGroup_InRange(Parquet.ParquetRowGroupReader,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,DiGi.Geometry.Planar.Classes.BoundingBox2D).boundingBox'></a>

`boundingBox` [DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.boundingbox2d 'DiGi\.Geometry\.Planar\.Classes\.BoundingBox2D')

The bounding box, in the source coordinate reference system, being queried\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the row group may contain rows inside the box and should be read; false when it can be skipped\.

<a name='DiGi.GIS.IO.Query.SourceId(System.Text.Json.Nodes.JsonObject)'></a>

## Query\.SourceId\(JsonObject\) Method

Returns the source identifier for a row from its attribute bag, trying the columns the open building datasets use, in order\.

The chain covers `id` (EUBUCCO, Overture, GHS-OBAT), `overture_id` (GHS-OBAT variants keyed on the Overture identifier) and `fid` (GeoPackage feature tables). Microsoft features carry no identifier at all, so that reader synthesizes one instead of calling this method.

```csharp
private static string? SourceId(System.Text.Json.Nodes.JsonObject? attributes);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.SourceId(System.Text.Json.Nodes.JsonObject).attributes'></a>

`attributes` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The attribute bag built from the source row\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The identifier as text, or null when the row carries none of the columns\.

<a name='DiGi.GIS.IO.Query.UnpopulatedColumnNames(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Column_)'></a>

## Query\.UnpopulatedColumnNames\(this Table, IEnumerable\<Column\>\) Method

Names the given columns that a table either does not carry at all, or carries with the type default in every row\.

The two cases are reported together on purpose, because a scorer cannot tell them apart: a column the table does not carry reads as the type default, so an absent feature and a feature that is zero everywhere reach a model as the same thing. Both mean the run that fills the column has not happened.

This is a different question from [DefaultOnlyColumnNames\(this Table\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.DefaultOnlyColumnNames(thisDiGi.Core.IO.Table.Classes.Table) 'DiGi\.GIS\.IO\.Query\.DefaultOnlyColumnNames\(this DiGi\.Core\.IO\.Table\.Classes\.Table\)'), which names columns that never vary. A column holding one county name in every row never varies and is perfectly populated; a detection column holding zero in every row is not.

```csharp
public static System.Collections.Generic.List<string> UnpopulatedColumnNames(this DiGi.Core.IO.Table.Classes.Table? table, System.Collections.Generic.IEnumerable<DiGi.Core.IO.Table.Classes.Column>? columns);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.UnpopulatedColumnNames(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Column_).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The table to inspect\. A null table carries nothing, so every column is reported\.

<a name='DiGi.GIS.IO.Query.UnpopulatedColumnNames(thisDiGi.Core.IO.Table.Classes.Table,System.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Column_).columns'></a>

`columns` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The columns to look for\. Columns are matched by stored column slug first and by display name second, the way the feature read projects them\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The names of the unpopulated columns, in the order given\. Empty when every column carries a value somewhere\.

<a name='DiGi.GIS.IO.Query.ValidateSrid(int,string)'></a>

## Query\.ValidateSrid\(int, string\) Method

Throws when a source file declares a spatial reference identifier outside the supported set \(EPSG:4326, EPSG:3035\)\.

Readers return footprints in the source coordinate reference system, so anything outside the two supported identifiers cannot be labelled honestly: failing loudly at enumeration start names the file, the identifier found and the set accepted, instead of silently reinterpreting coordinates that were never converted.

```csharp
private static void ValidateSrid(int srid, string path);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.ValidateSrid(int,string).srid'></a>

`srid` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The spatial reference identifier declared by the file\.

<a name='DiGi.GIS.IO.Query.ValidateSrid(int,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the file being read, used in the exception message\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
Thrown when the identifier is neither 4326 nor 3035\.

<a name='DiGi.GIS.IO.Query.YearBuiltLabels(thisDiGi.Core.IO.Table.Classes.Table)'></a>

## Query\.YearBuiltLabels\(this Table\) Method

Extracts the training labels of one stored building data table, by building reference\.

Delegates to the IEnumerable<Table?> overload with a single element so the two cannot disagree.

```csharp
public static System.Collections.Generic.Dictionary<string,short> YearBuiltLabels(this DiGi.Core.IO.Table.Classes.Table? table);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.YearBuiltLabels(thisDiGi.Core.IO.Table.Classes.Table).table'></a>

`table` [DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')

The stored building data table to take labels from, or null\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
The construction year of each labelled building, by reference\. Empty when the table is null or holds no labels\.

<a name='DiGi.GIS.IO.Query.YearBuiltLabels(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_)'></a>

## Query\.YearBuiltLabels\(this IEnumerable\<Table\>\) Method

Extracts the training labels from the stored `User year built` column, by building reference\.

The value is the most frequent exact user year over every stored record of the building. The rule and its tie-breaks are defined once, on `DiGi.GIS.Query.MostFrequentUserYearBuilt`, and applied when `DiGi.GIS.IO.Modify.Update_Building2D_YearBuilt` writes the column. This method reads, it does not re-derive.

Only this column is read, because the two year built columns beside it are the regressor's own territory. `Predicted year built` is this model's own output, and `Calculated year built` equals the prediction wherever no user year exists: on the counties this model trains on the stored user and predicted years disagree on roughly a quarter of the buildings, so reading either would train the regressor on its predecessor, which reads as an accuracy gain rather than as a defect.

An empty cell is an unlabelled building, not year zero. A table without the column - a county the Year Built update has not reached - gives no labels.

```csharp
public static System.Collections.Generic.Dictionary<string,short> YearBuiltLabels(this System.Collections.Generic.IEnumerable<DiGi.Core.IO.Table.Classes.Table?>? tables);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.YearBuiltLabels(thisSystem.Collections.Generic.IEnumerable_DiGi.Core.IO.Table.Classes.Table_).tables'></a>

`tables` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.Core\.IO\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.table 'DiGi\.Core\.IO\.Table\.Classes\.Table')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The stored building data tables to take labels from, typically one page or one county each\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
The construction year of each labelled building, by reference\. Empty when nothing was labelled\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionFeatureGroups(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Query\.YearBuiltPredictionFeatureGroups\(Range\<int\>, IEnumerable\<double\>\) Method

Retrieves the Year Built prediction input features, grouped by the run that populates them\.

This is the definition [YearBuiltPredictionInputColumns\(Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionInputColumns\(DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') is assembled from, so the allow-list and the groups cannot drift apart. Read the allow-list when the question is which columns the regressor may see, and read this when the question is which of them a county is actually carrying.

```csharp
public static System.Collections.Generic.Dictionary<string,System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column>> YearBuiltPredictionFeatureGroups(DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionFeatureGroups(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for detection and population features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionFeatureGroups(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses for radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')  
A dictionary keyed by [YearBuiltPredictionFeatureGroup](DiGi.GIS.IO.Constants.md#DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup 'DiGi\.GIS\.IO\.Constants\.YearBuiltPredictionFeatureGroup') holding the columns of each group, in the order the allow\-list lists them\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumnNames(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Query\.YearBuiltPredictionInputColumnNames\(Range\<int\>, IEnumerable\<double\>\) Method

Retrieves the names the Year Built prediction input features are bound by, for the specified range of years and radial radiuses\.

These are the [DiGi\.Core\.IO\.Table\.Classes\.Column\.Name](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column.name 'DiGi\.Core\.IO\.Table\.Classes\.Column\.Name') values - the names a `ModelInput` member is bound to, not the stored column identifiers - and they are the one place an orchestrator compares its options against the predictor's stated contract: a name the model needs but the options do not ask for is the silent-degradation case, and a name the options ask for but the model does not use is the harmless surplus.

Built from [YearBuiltPredictionInputColumns\(Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionInputColumns\(DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') so the allow-list and its names cannot drift apart.

```csharp
public static System.Collections.Generic.HashSet<string> YearBuiltPredictionInputColumnNames(DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumnNames(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for detection and temporal features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumnNames(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses for radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[System\.Collections\.Generic\.HashSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1 'System\.Collections\.Generic\.HashSet\`1')  
The set of input feature names the projection for the given options asks for\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_)'></a>

## Query\.YearBuiltPredictionInputColumns\(Range\<int\>, IEnumerable\<double\>\) Method

Retrieves the list of columns permitted as input features for the Year Built prediction machine learning model across the specified range of years and radial radiuses\.

Assembled from [YearBuiltPredictionFeatureGroups\(Range&lt;int&gt;, IEnumerable&lt;double&gt;\)](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.YearBuiltPredictionFeatureGroups(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_) 'DiGi\.GIS\.IO\.Query\.YearBuiltPredictionFeatureGroups\(DiGi\.Core\.Classes\.Range\<int\>, System\.Collections\.Generic\.IEnumerable\<double\>\)') rather than listed a second time, so a column added to a group reaches the allow-list without anyone remembering to add it twice.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of years for detection and temporal features\. Defaults to 2008\.\.2025 when null\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionInputColumns(DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of radiuses for radial ratio features\. Defaults to 200, 400, 600, 1000 when null\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the allowed input features\.

<a name='DiGi.GIS.IO.Query.YearBuiltPredictionOutputColumns()'></a>

## Query\.YearBuiltPredictionOutputColumns\(\) Method

Retrieves the list of columns written as output by the Year Built prediction machine learning model pipeline\.

```csharp
public static System.Collections.Generic.List<DiGi.Core.IO.Table.Classes.Column> YearBuiltPredictionOutputColumns();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Core\.IO\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.table.classes.column 'DiGi\.Core\.IO\.Table\.Classes\.Column') instances representing the model output columns\.

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata'></a>

## Query\.GeoParquetMetadata Class

The file\-level GeoParquet facts a read needs in one place: the spatial reference identifier, the primary geometry column and the covering columns resolved against the schema for row\-group pruning\.

```csharp
private sealed class Query.GeoParquetMetadata
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → GeoParquetMetadata
### Constructors

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField)'></a>

## GeoParquetMetadata\(int, string, DataField, DataField, DataField, DataField\) Constructor

Initializes a new instance of the [GeoParquetMetadata](DiGi.GIS.IO.md#DiGi.GIS.IO.Query.GeoParquetMetadata 'DiGi\.GIS\.IO\.Query\.GeoParquetMetadata') class\.

```csharp
public GeoParquetMetadata(int srid, string geometryColumn, Parquet.Schema.DataField? coveringMinX, Parquet.Schema.DataField? coveringMaxX, Parquet.Schema.DataField? coveringMinY, Parquet.Schema.DataField? coveringMaxY);
```
#### Parameters

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField).srid'></a>

`srid` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The spatial reference identifier declared by the file\.

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField).geometryColumn'></a>

`geometryColumn` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The primary geometry column name\.

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField).coveringMinX'></a>

`coveringMinX` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's minimum X, or null when the file carries no covering\.

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField).coveringMaxX'></a>

`coveringMaxX` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's maximum X, or null when the file carries no covering\.

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField).coveringMinY'></a>

`coveringMinY` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's minimum Y, or null when the file carries no covering\.

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeoParquetMetadata(int,string,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField,Parquet.Schema.DataField).coveringMaxY'></a>

`coveringMaxY` [Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

The covering column holding each row's maximum Y, or null when the file carries no covering\.
### Properties

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.CoveringMaxX'></a>

## Query\.GeoParquetMetadata\.CoveringMaxX Property

Gets the covering column holding each row's maximum X, or null when the file carries no covering\.

```csharp
public Parquet.Schema.DataField? CoveringMaxX { get; }
```

#### Property Value
[Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.CoveringMaxY'></a>

## Query\.GeoParquetMetadata\.CoveringMaxY Property

Gets the covering column holding each row's maximum Y, or null when the file carries no covering\.

```csharp
public Parquet.Schema.DataField? CoveringMaxY { get; }
```

#### Property Value
[Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.CoveringMinX'></a>

## Query\.GeoParquetMetadata\.CoveringMinX Property

Gets the covering column holding each row's minimum X, or null when the file carries no covering\.

```csharp
public Parquet.Schema.DataField? CoveringMinX { get; }
```

#### Property Value
[Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.CoveringMinY'></a>

## Query\.GeoParquetMetadata\.CoveringMinY Property

Gets the covering column holding each row's minimum Y, or null when the file carries no covering\.

```csharp
public Parquet.Schema.DataField? CoveringMinY { get; }
```

#### Property Value
[Parquet\.Schema\.DataField](https://learn.microsoft.com/en-us/dotnet/api/parquet.schema.datafield 'Parquet\.Schema\.DataField')

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.GeometryColumn'></a>

## Query\.GeoParquetMetadata\.GeometryColumn Property

Gets the primary geometry column name\.

```csharp
public string GeometryColumn { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.HasCovering'></a>

## Query\.GeoParquetMetadata\.HasCovering Property

Gets whether all four covering columns resolved against the schema, which is what makes row\-group pruning possible\.

```csharp
public bool HasCovering { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.IO.Query.GeoParquetMetadata.Srid'></a>

## Query\.GeoParquetMetadata\.Srid Property

Gets the spatial reference identifier declared by the file\.

```csharp
public int Srid { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')