#### [DiGi\.GIS\.IO](DiGi.GIS.IO.Overview.md 'DiGi\.GIS\.IO\.Overview')

## DiGi\.GIS\.IO\.Classes Namespace
### Classes

<a name='DiGi.GIS.IO.Classes.Footprint'></a>

## Footprint Class

One building footprint read from an open building dataset, carrying the source identifier, the source coordinate reference system, the full source attributes and the per\-object provenance\.

The readers never convert the source geometry and never renumber the source identifiers: [SourceSrid](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.SourceSrid 'DiGi\.GIS\.IO\.Classes\.Footprint\.SourceSrid') states the coordinate reference system the geometry is expressed in, so a footprint read from an EPSG:3035 file stays in EPSG:3035 and one read from an EPSG:4326 file stays in EPSG:4326. A caller that needs a common coordinate reference system transforms explicitly.

[Attributes](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.Attributes 'DiGi\.GIS\.IO\.Classes\.Footprint\.Attributes') holds every source column verbatim, including columns that also appear in [Provenance](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.Provenance 'DiGi\.GIS\.IO\.Classes\.Footprint\.Provenance'). [Provenance](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.Provenance 'DiGi\.GIS\.IO\.Classes\.Footprint\.Provenance') holds the subset that states where the geometry came from, in the shape the building_dataset release register expects (DiGi-Organization/DiGi.GIS.PostgreSQL#125), so provenance travels with the object instead of being re-derived from the dataset name later.

[LicenceException](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint.LicenceException 'DiGi\.GIS\.IO\.Classes\.Footprint\.LicenceException') is set only for EUBUCCO rows whose `geometry_source` carries a regional licence exception (Prague, Abruzzo). Such rows are flagged, never dropped, so a country file reads back at full row count while a consumer can still filter down to the ODbL-only subset.

```csharp
public class Footprint : DiGi.Core.Classes.SerializableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → Footprint
### Constructors

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(DiGi.GIS.IO.Classes.Footprint)'></a>

## Footprint\(Footprint\) Constructor

Initializes a new instance of the [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') class by copying another instance\.

```csharp
public Footprint(DiGi.GIS.IO.Classes.Footprint? footprint);
```
#### Parameters

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(DiGi.GIS.IO.Classes.Footprint).footprint'></a>

`footprint` [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint')

The source footprint to copy from\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string)'></a>

## Footprint\(string, int, IGeometry2D, JsonObject, JsonObject, string\) Constructor

Initializes a new instance of the [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') class\.

```csharp
public Footprint(string? sourceId, int sourceSrid, DiGi.Geometry.Planar.Interfaces.IGeometry2D? geometry, System.Text.Json.Nodes.JsonObject? attributes, System.Text.Json.Nodes.JsonObject? provenance, string? licenceException);
```
#### Parameters

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string).sourceId'></a>

`sourceId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identifier the source dataset gives the footprint, or a synthesized one when the source gives none \(Microsoft\)\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string).sourceSrid'></a>

`sourceSrid` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The spatial reference identifier the geometry is expressed in\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string).geometry'></a>

`geometry` [DiGi\.Geometry\.Planar\.Interfaces\.IGeometry2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.interfaces.igeometry2d 'DiGi\.Geometry\.Planar\.Interfaces\.IGeometry2D')

The footprint geometry in the source coordinate reference system, or null when the source row has none\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string).attributes'></a>

`attributes` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

All source attributes, or null when the source row has none\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string).provenance'></a>

`provenance` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

Per\-object provenance, or null when the dataset defines none\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(string,int,DiGi.Geometry.Planar.Interfaces.IGeometry2D,System.Text.Json.Nodes.JsonObject,System.Text.Json.Nodes.JsonObject,string).licenceException'></a>

`licenceException` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The regional licence exception flagged on the row, or null when none applies\.

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(System.Text.Json.Nodes.JsonObject)'></a>

## Footprint\(JsonObject\) Constructor

Initializes a new instance of the [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') class from a JSON object\.

```csharp
public Footprint(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.IO.Classes.Footprint.Footprint(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the footprint data\.
### Properties

<a name='DiGi.GIS.IO.Classes.Footprint.Attributes'></a>

## Footprint\.Attributes Property

Gets a deep copy of all source attributes, keyed by source column name\.

```csharp
public System.Text.Json.Nodes.JsonObject? Attributes { get; }
```

#### Property Value
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

<a name='DiGi.GIS.IO.Classes.Footprint.Geometry'></a>

## Footprint\.Geometry Property

Gets the footprint geometry in the source coordinate reference system, or null when the source row has none\.

```csharp
public DiGi.Geometry.Planar.Interfaces.IGeometry2D? Geometry { get; }
```

#### Property Value
[DiGi\.Geometry\.Planar\.Interfaces\.IGeometry2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.interfaces.igeometry2d 'DiGi\.Geometry\.Planar\.Interfaces\.IGeometry2D')

<a name='DiGi.GIS.IO.Classes.Footprint.LicenceException'></a>

## Footprint\.LicenceException Property

Gets the regional licence exception flagged on the row \(CC\-BY\-SA for Prague, CC\-BY\-NC for Abruzzo\), or null when none applies\.

```csharp
public string? LicenceException { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Classes.Footprint.Provenance'></a>

## Footprint\.Provenance Property

Gets a deep copy of the per\-object provenance, or null when the dataset defines none\.

```csharp
public System.Text.Json.Nodes.JsonObject? Provenance { get; }
```

#### Property Value
[System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

<a name='DiGi.GIS.IO.Classes.Footprint.SourceId'></a>

## Footprint\.SourceId Property

Gets the identifier the source dataset gives the footprint, or the synthesized one when the source gives none\.

```csharp
public string? SourceId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Classes.Footprint.SourceSrid'></a>

## Footprint\.SourceSrid Property

Gets the spatial reference identifier the geometry is expressed in\.

```csharp
public int SourceSrid { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')
### Methods

<a name='DiGi.GIS.IO.Classes.Footprint.Clone()'></a>

## Footprint\.Clone\(\) Method

Creates a deep copy of this [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') instance\.

```csharp
public override DiGi.Core.Interfaces.ISerializableObject? Clone();
```

Implements [Clone\(\)](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1.clone 'DiGi\.Core\.Interfaces\.ICloneableObject\`1\.Clone')

#### Returns
[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')  
A new [Footprint](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.Footprint 'DiGi\.GIS\.IO\.Classes\.Footprint') instance with the same data, or null if cloning fails\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness'></a>

## YearBuiltPredictorReadiness Class

States whether a [IYearBuiltPredictor](DiGi.GIS.IO.Interfaces.md#DiGi.GIS.IO.Interfaces.IYearBuiltPredictor 'DiGi\.GIS\.IO\.Interfaces\.IYearBuiltPredictor') can score at all, and what it expects, probed before a run starts\.

The seam returns this rather than a bare flag so the reason a predictor cannot score travels with the answer - an unattended run learns in seconds that the trained model is missing rather than after exporting a county of imagery. It is the single surface the orchestrator checks, so the contract a predictor expects - the year range and radiuses the loaded model was trained on - travels with the runnability rather than living only beside the model.

[Years](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Years 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness\.Years') and [Radiuses](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Radiuses 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness\.Radiuses') state that contract. When both are [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') the predictor states no contract and the orchestrator's feature-contract check is skipped; when they are set, the orchestrator compares the run's options against them before it reads a county.

[RequiredFeatureGroups](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.RequiredFeatureGroups 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness\.RequiredFeatureGroups') states which of the feature groups the predictor requires populated before a county is scored; when it is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') the orchestrator keeps its historical default (DiGi-Organization/DiGi.GIS.YOLO.UI#27).

It is a local probe result, computed in the host and consumed in the same call, so it is not a SerializableObject and carries no serialization surface.

```csharp
public sealed class YearBuiltPredictorReadiness
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → YearBuiltPredictorReadiness
### Constructors

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string)'></a>

## YearBuiltPredictorReadiness\(bool, IEnumerable\<string\>, Range\<int\>, IEnumerable\<double\>, IEnumerable\<string\>, string\) Constructor

Initializes a new instance of the [YearBuiltPredictorReadiness](DiGi.GIS.IO.Classes.md#DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness 'DiGi\.GIS\.IO\.Classes\.YearBuiltPredictorReadiness') class\.

```csharp
public YearBuiltPredictorReadiness(bool runnable, System.Collections.Generic.IEnumerable<string>? messages=null, DiGi.Core.Classes.Range<int>? years=null, System.Collections.Generic.IEnumerable<double>? radiuses=null, System.Collections.Generic.IEnumerable<string>? requiredFeatureGroups=null, string? modelId=null);
```
#### Parameters

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string).runnable'></a>

`runnable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the predictor can score at all\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string).messages'></a>

`messages` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The diagnostics explaining why it cannot score\. Null or empty when it can score\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string).years'></a>

`years` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The year range the loaded model was trained on, or null when the predictor states no contract\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string).radiuses'></a>

`radiuses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The radiuses the loaded model was trained on, in metres, or null when the predictor states no contract\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string).requiredFeatureGroups'></a>

`requiredFeatureGroups` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The feature\-group names the predictor requires populated, or null when it states none and the orchestrator keeps its historical default\.

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.YearBuiltPredictorReadiness(bool,System.Collections.Generic.IEnumerable_string_,DiGi.Core.Classes.Range_int_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_string_,string).modelId'></a>

`modelId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identity of the loaded model, normally the lowercase hexadecimal SHA\-256 of its file, or null when the predictor states none\.
### Properties

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Messages'></a>

## YearBuiltPredictorReadiness\.Messages Property

Gets the diagnostics that explain the answer \- why the predictor cannot score\. Empty when it can score\.

```csharp
public System.Collections.Generic.List<string> Messages { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.ModelId'></a>

## YearBuiltPredictorReadiness\.ModelId Property

Gets the identity of the loaded model \- normally the lowercase hexadecimal SHA\-256 of its file \- or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the predictor states none\.

The orchestrator stamps it on every prediction it stores (`PredictedYearBuilt.ModelId`), so the history can tell one model's predictions from another's after the model file is replaced in place - a file name says nothing then (DiGi-Organization/DiGi.GIS.YOLO.UI#26).

```csharp
public string? ModelId { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Radiuses'></a>

## YearBuiltPredictorReadiness\.Radiuses Property

Gets the radiuses the loaded model was trained on, in metres, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the predictor states no contract\.

```csharp
public System.Collections.Generic.List<double>? Radiuses { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.RequiredFeatureGroups'></a>

## YearBuiltPredictorReadiness\.RequiredFeatureGroups Property

Gets the feature\-group names the predictor requires populated before a county is scored, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when it states none and the orchestrator keeps its historical default\.

The values are [YearBuiltPredictionFeatureGroup](DiGi.GIS.IO.Constants.md#DiGi.GIS.IO.Constants.YearBuiltPredictionFeatureGroup 'DiGi\.GIS\.IO\.Constants\.YearBuiltPredictionFeatureGroup') names. A predictor that reads only a subset of the feature groups states it, so a group it does not read - such as the population columns of a first-detection heuristic - warns rather than refuses a county (DiGi-Organization/DiGi.GIS.YOLO.UI#27).

```csharp
public System.Collections.Generic.List<string>? RequiredFeatureGroups { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Runnable'></a>

## YearBuiltPredictorReadiness\.Runnable Property

Gets whether the predictor can score at all\.

```csharp
public bool Runnable { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.IO.Classes.YearBuiltPredictorReadiness.Years'></a>

## YearBuiltPredictorReadiness\.Years Property

Gets the year range the loaded model was trained on, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') when the predictor states no contract\.

```csharp
public DiGi.Core.Classes.Range<int>? Years { get; }
```

#### Property Value
[DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')