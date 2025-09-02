# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Codezerg.FluentHtml is a fluent HTML DSL/view engine for C# that enables type-safe HTML generation with a clean, composable API. It uses a uniform factory pattern with parameterless tag methods and lowercase fluent attribute chaining. The library supports all HTML5 elements, htmx integration, and provides a component system for reusable UI patterns.

## Build and Test Commands

```bash
# Build the solution
dotnet build

# Run tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Build in release mode
dotnet build -c Release

# Pack NuGet package
dotnet pack -c Release

# Run a specific test
dotnet test --filter "FullyQualifiedName~HtmlTests.TextNode_Should_HtmlEncode_Content"

# Run demo application
cd demo/Codezerg.FluentHtml.Demo
dotnet run
```

## Architecture

### Core Components

**Node Hierarchy:**
- `Node` (abstract base) - Base class for all renderable elements
  - `Element` - Represents HTML elements with tag name, attributes, and children
  - `TextNode` - Represents text content with automatic HTML encoding

**HTML Elements:** Located in `src/Codezerg.FluentHtml/Elements/`

**Document Structure:**
- `HTMLHtmlElement` - Root HTML element
- `HTMLMetaElement`, `HTMLLinkElement`, `HTMLScriptElement` - Head elements

**Forms & Input:**
- `HTMLFormElement`, `HTMLInputElement`, `HTMLSelectElement`, `HTMLTextAreaElement`
- `HTMLButtonElement`, `HTMLLabelElement`, `HTMLOptionElement`
- `HTMLFieldSetElement`, `HTMLLegendElement`

**Media Elements:**
- `HTMLAudioElement`, `HTMLVideoElement`, `HTMLSourceElement`, `HTMLTrackElement`
- `HTMLImageElement`, `HTMLIFrameElement`, `HTMLEmbedElement`
- `HTMLObjectElement`, `HTMLParamElement`

**Table Elements:**
- `HTMLTableElement`, `HTMLTableSectionElement`, `HTMLTableRowElement`
- `HTMLTableCellElement`, `HTMLTableCaptionElement`
- `HTMLTableColElement`, `HTMLTableColGroupElement`

**Semantic Elements:**
- `HTMLSectionElement`, `HTMLArticleElement`, `HTMLNavElement`
- `HTMLAsideElement`, `HTMLHeaderElement`, `HTMLFooterElement`
- `HTMLAddressElement`, `HTMLFigureElement`, `HTMLFigCaptionElement`

**Text Formatting:**
- `HTMLHeadingElement` (h1-h6), `HTMLParagraphElement`
- `HTMLDivElement`, `HTMLSpanElement`, `HTMLPreElement`
- `HTMLBlockQuoteElement`, `HTMLStrongElement`, `HTMLEmElement`
- `HTMLSmallElement`, `HTMLMarkElement`, `HTMLDelElement`, `HTMLInsElement`
- `HTMLSubElement`, `HTMLSupElement`, `HTMLCodeElement`
- `HTMLKbdElement`, `HTMLSampElement`, `HTMLVarElement`

**Interactive Elements:**
- `HTMLDetailsElement`, `HTMLDialogElement`
- `HTMLProgressElement`, `HTMLMeterElement`
- `HTMLTimeElement`, `HTMLDataElement`

**Extension System:** Located in `src/Codezerg.FluentHtml/Extensions/`
- `GlobalAttributeExtensions` - Universal HTML attributes and utilities
  - Core attributes: `id`, `@class`, `style`, `title`, `lang`, `dir`
  - Accessibility: `role`, `arialabel`, `ariadescribedby`, `ariahidden`
  - Data attributes: `data(name, value)`
  - Events: `onclick`, `onchange`, `onsubmit`, `onfocus`, `onblur`
  - Boolean attributes: `hidden`, `contenteditable`, `draggable`, `spellcheck`
  - Utility methods: `attr`, `addChild`, `addChildren`
- `HtmxExtensions` - htmx integration
  - CRUD: `hx_get`, `hx_post`, `hx_put`, `hx_delete`
  - Targeting: `hx_target`, `hx_swap` (with HxSwap enum)
  - Triggers: `hx_trigger` (with HxTrigger enum)
  - Features: `hx_confirm`, `hx_boost`, `hx_push_url`, `hx_vals`, `hx_indicator`

**Component System:**
- `Components` class - Pre-built reusable UI components
  - Layout: `MyLayout`, `MyHeader`, `MyFooter`
  - UI Elements: `Card`, `Alert`, `NavigationMenu`
  - Forms: `FormGroup`

**Entry Points:**
- `Html` class - Static factory methods for creating all HTML elements
- `Renderer` class - Methods for rendering nodes to HTML strings
  - `Render(Node node)` - Renders a node tree to HTML string
  - `RenderElement(Element element)` - Internal element rendering

### Design Patterns

1. **Uniform Factory Pattern**: All HTML tag creation methods follow consistent patterns:
   - Void elements (img, input, meta, br, hr, etc.) are always parameterless
   - Container elements accept `params Node[]` for children
   - All factory methods in `Html` class are static

2. **Fluent Extension Methods**: 
   - All attributes are lowercase extension methods that return the element for chaining
   - Method names match HTML attribute names (with @ prefix for C# keywords)
   - Consistent return type `T where T : Element` for all extensions

3. **Type Safety**: 
   - Each HTML element has its own strongly-typed class
   - Element-specific attributes are defined as extension methods on the appropriate type
   - Compile-time checking prevents invalid attribute usage

4. **Component Composition**:
   - Components are static methods returning `Element` or `Node`
   - Components can nest other components for complex UI structures
   - Parameters allow customization while maintaining consistency

### Testing

Tests use xUnit framework and are located in `tests/Codezerg.FluentHtml.Tests/`. 

**Test Files:**
- `HtmlTests.cs` - Core functionality tests
- `NewElementsTests.cs` - Tests for newly added HTML5 elements

**Key Test Areas:**
- HTML encoding for XSS protection
- Self-closing/void tag rendering
- Nested structure rendering
- Attribute handling and escaping
- Component composition
- htmx attribute generation

## Key Implementation Details

- **XSS Protection**: TextNode automatically HTML-encodes content using `System.Net.WebUtility.HtmlEncode`
- **Void Elements**: Defined in `Element.cs` as a static HashSet (area, base, br, col, embed, hr, img, input, link, meta, param, source, track, wbr)
- **C# Keywords**: Use @ prefix for reserved words (e.g., `@class`, `@base`, `@if`, `@foreach`, `@for`)
- **Target Framework**: Library targets .NET Standard 2.0 for broad compatibility
- **Test Framework**: Tests run on .NET 6.0 using xUnit
- **Demo Project**: Located in `demo/Codezerg.FluentHtml.Demo/`, demonstrates usage patterns

## Usage Examples

### Basic HTML Generation
```csharp
var html = Html.div(
    Html.h1(Html.text("Hello World")).@class("title"),
    Html.p(Html.text("Welcome to FluentHtml")).id("intro")
).@class("container");
```

### Form with htmx
```csharp
var form = Html.form(
    Html.input().type("text").name("username").placeholder("Username"),
    Html.button(Html.text("Submit")).type("submit")
)
.hx_post("/api/login")
.hx_target("#result")
.hx_swap(HxSwap.innerHTML);
```

### Component Usage
```csharp
var page = Components.MyLayout("Home Page",
    Html.div(
        Components.Card("Feature 1", "Description of feature"),
        Components.Alert("Success!", "success")
    )
);
```

## Coding Standards

- All HTML element creation methods are lowercase (matching HTML tags)
- All attribute extension methods are lowercase (matching HTML attributes)
- Component methods use PascalCase
- Enum values follow C# naming conventions
- Extension methods preserve exact indentation from source files