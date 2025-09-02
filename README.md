# Codezerg.FluentHtml

A fluent HTML DSL/view engine for C# that enables type-safe HTML generation with a clean, composable API. Features a uniform factory pattern with parameterless tag methods and lowercase fluent attribute chaining. Includes full HTML5 support, htmx integration, and a component system for building reusable UI patterns.

## Features

- **Complete HTML5 Support** - All HTML5 elements with strongly-typed classes
- **Uniform Factory Pattern** - Consistent API with parameterless void elements
- **Lowercase Fluent API** - All attributes use lowercase methods for consistency
- **Type-safe HTML generation** - No string concatenation or typos
- **htmx Integration** - Built-in support for htmx attributes
- **Component System** - Pre-built components and easy custom component creation
- **Tag-specific attributes** - Specialized attribute methods per HTML element type
- **Auto HTML encoding** - Automatic protection against XSS attacks
- **Conditional rendering** - Built-in `if` and `foreach` helpers
- **.NET Standard 2.0** - Compatible with .NET Framework, .NET Core, and .NET 5+

## Quick Start

```csharp
using Codezerg.FluentHtml;

var page = Html.html(
    Html.head(
        Html.meta().charset("utf-8"),
        Html.title(Html.text("Hello World"))
    ),
    Html.body(
        Html.h1(Html.text("Welcome!")).@class("title"),
        Html.p(Html.text("This is FluentHtml.")).id("intro")
    )
);

Console.WriteLine(Renderer.Render(page));
```

### Cleaner Syntax with Static Import

```csharp
using Codezerg.FluentHtml;
using static Codezerg.FluentHtml.Html;

var page = html(
    head(
        meta().charset("utf-8"),
        title(text("Hello World"))
    ),
    body(
        h1(text("Welcome!")).@class("title"),
        p(text("This is FluentHtml.")).id("intro")
    )
);

Console.WriteLine(Renderer.Render(page));
```

## Installation

```bash
dotnet add package Codezerg.FluentHtml
```

## API Design Principles

### 1. Uniform Factory Pattern
All HTML tag methods follow consistent patterns:

```csharp
// Void elements - always parameterless
Html.meta()
Html.link()
Html.input()
Html.img()
Html.br()
Html.hr()

// Container elements - accept children via params
Html.div(/* children */)
Html.p(/* children */)
Html.ul(/* children */)
Html.section(/* children */)
```

### 2. Lowercase Attribute Methods
All attributes are set via lowercase extension methods:

```csharp
Html.div()
    .id("main")
    .@class("container")  // @ prefix for C# keywords
    .style("padding: 10px")
    .data("user-id", "123")
```

### 3. Strongly-Typed Elements
Each HTML element has its own class with appropriate attributes:

```csharp
// Meta tags
Html.meta().charset("utf-8")
Html.meta().name("viewport").content("width=device-width")

// Links
Html.link().rel("stylesheet").href("/style.css")

// Forms
Html.form().method("post").action("/submit").novalidate()

// Inputs
Html.input().type("email").name("email").required()

// Media
Html.img().src("/logo.png").alt("Logo").loading("lazy")
Html.video().src("/movie.mp4").controls().autoplay()
Html.audio().src("/song.mp3").controls()
```

## Usage Examples

### Content Addition Patterns

FluentHtml offers flexible ways to add content to elements:

```csharp
using static Codezerg.FluentHtml.Html;

// Method 1: Immediate content via constructor
var div1 = div(
    h1(text("Hello")),
    p(text("World"))
).@class("container");

// Method 2: Deferred content via extension methods
var div2 = div()
    .content(h1().text("Hello"))
    .content(p().text("World"))
    .@class("container");

// Method 3: Mixed approach
var div3 = div(
    h1().text("Hello")  // Creates h1 then adds text
).content(
    p(text("World"))    // Adds p with text later
).@class("container");
```

### Basic HTML Structure

```csharp
using static Codezerg.FluentHtml.Html;

var page = html(
    head(
        meta().charset("utf-8"),
        title(text("My Page")),
        link().rel("stylesheet").href("/css/style.css")
    ),
    body(
        header(
            nav(/* navigation items */)
        ),
        main(
            h1(text("Welcome")),
            p(text("Content here"))
        ),
        footer(
            p(text("© 2024"))
        )
    )
);
```

### Forms with Validation

```csharp
var form = Html.form(
    Html.fieldset(
        Html.legend(Html.text("Login")),
        
        Html.label(Html.text("Email")).@for("email"),
        Html.input()
            .type("email")
            .id("email")
            .name("email")
            .placeholder("your@email.com")
            .required(),
        
        Html.label(Html.text("Password")).@for("password"),
        Html.input()
            .type("password")
            .id("password")
            .name("password")
            .minlength("8")
            .required(),
        
        Html.button(Html.text("Submit")).type("submit")
    )
)
.method("post")
.action("/login");
```

### htmx Integration

```csharp
// Dynamic content loading
Html.div()
    .hx_get("/api/users")
    .hx_trigger(HxTrigger.load)
    .hx_swap(HxSwap.innerHTML)

// Form with AJAX submission
Html.form(
    Html.input().type("text").name("search"),
    Html.button(Html.text("Search"))
)
.hx_post("/api/search")
.hx_target("#results")
.hx_indicator("#spinner")

// Interactive button
Html.button(Html.text("Delete"))
    .hx_delete("/api/item/123")
    .hx_confirm("Are you sure?")
    .hx_swap(HxSwap.outerHTML)
```

### Pre-built Components

```csharp
// Use included components
var page = Components.MyLayout("Home Page",
    Html.div(
        Components.NavigationMenu(
            ("Home", "/"),
            ("About", "/about"),
            ("Contact", "/contact")
        ),
        Components.Card("Feature", "Description here"),
        Components.Alert("Success!", "success")
    )
);

// Form components
var form = Html.form(
    Components.FormGroup("Username", "username", "text", "Enter username"),
    Components.FormGroup("Password", "password", "password"),
    Html.button(Html.text("Login")).type("submit")
);
```

### Custom Components

```csharp
public static class MyComponents
{
    public static Element ProductCard(Product product)
    {
        return Html.article(
            Html.img().src(product.ImageUrl).alt(product.Name),
            Html.h3(Html.text(product.Name)),
            Html.p(Html.text(product.Description)),
            Html.span(Html.text($"${product.Price}")).@class("price"),
            Html.button(Html.text("Add to Cart"))
                .data("product-id", product.Id.ToString())
                .@class("btn-add-to-cart")
        ).@class("product-card");
    }
    
    public static Element DataTable<T>(IEnumerable<T> items, params (string header, Func<T, string> value)[] columns)
    {
        return Html.table(
            Html.thead(
                Html.tr(
                    Html.@foreach(columns, col => 
                        Html.th(Html.text(col.header))
                    )
                )
            ),
            Html.tbody(
                Html.@foreach(items, item =>
                    Html.tr(
                        Html.@foreach(columns, col =>
                            Html.td(Html.text(col.value(item)))
                        )
                    )
                )
            )
        ).@class("data-table");
    }
}
```

### Semantic HTML5

```csharp
var article = Html.article(
    Html.header(
        Html.h1(Html.text("Article Title")),
        Html.time(Html.text("2024-01-01")).datetime("2024-01-01")
    ),
    Html.section(
        Html.p(Html.text("Article content...")),
        Html.figure(
            Html.img().src("/image.jpg").alt("Description"),
            Html.figcaption(Html.text("Image caption"))
        )
    ),
    Html.aside(
        Html.h3(Html.text("Related Links")),
        Html.nav(/* links */)
    ),
    Html.footer(
        Html.p(Html.text("Author: John Doe"))
    )
);
```

### Interactive Elements

```csharp
// Progress and meters
Html.progress().value("70").max("100")
Html.meter().value("6").min("0").max("10")

// Details/Summary (collapsible)
Html.details(
    Html.summary(Html.text("Click to expand")),
    Html.p(Html.text("Hidden content here"))
)

// Dialog (modal)
Html.dialog(
    Html.h2(Html.text("Dialog Title")),
    Html.p(Html.text("Dialog content")),
    Html.button(Html.text("Close")).onclick("this.closest('dialog').close()")
).id("myDialog")

// Time element
Html.time(Html.text("January 1, 2024")).datetime("2024-01-01")
```

### Tables

```csharp
var table = Html.table(
    Html.caption(Html.text("Sales Data")),
    Html.colgroup(
        Html.col().span("1").style("background-color: #f0f0f0"),
        Html.col().span("2")
    ),
    Html.thead(
        Html.tr(
            Html.th(Html.text("Product")),
            Html.th(Html.text("Q1")),
            Html.th(Html.text("Q2"))
        )
    ),
    Html.tbody(
        Html.tr(
            Html.td(Html.text("Widget A")),
            Html.td(Html.text("100")),
            Html.td(Html.text("150"))
        )
    ),
    Html.tfoot(
        Html.tr(
            Html.td(Html.text("Total")).colspan("1"),
            Html.td(Html.text("100")),
            Html.td(Html.text("150"))
        )
    )
).@class("sales-table");
```

## Conditional Rendering

```csharp
// If statement
Html.@if(isLoggedIn,
    () => Html.p(Html.text($"Welcome, {username}!")),
    () => Html.a(Html.text("Please log in")).href("/login")
)

// Foreach loop
Html.ul(
    Html.@foreach(items, item => 
        Html.li(Html.text(item.Name))
    )
)

// Foreach with index
Html.ol(
    Html.@foreach(items, (item, index) => 
        Html.li(Html.text($"{index + 1}. {item.Name}"))
    )
)
```

## Complete Element Reference

### Document Structure
- `html`, `head`, `body`, `title`, `meta`, `link`, `script`, `style`, `base`

### Content Sections
- `header`, `nav`, `main`, `section`, `article`, `aside`, `footer`, `address`

### Text Content
- `h1`-`h6`, `p`, `div`, `span`, `pre`, `blockquote`
- `ul`, `ol`, `li`, `dl`, `dt`, `dd`
- `figure`, `figcaption`

### Text Formatting
- `strong`, `em`, `small`, `mark`, `del`, `ins`, `sub`, `sup`
- `code`, `kbd`, `samp`, `var`, `data`, `time`
- `abbr`, `cite`, `dfn`, `q`

### Forms
- `form`, `fieldset`, `legend`, `label`
- `input`, `textarea`, `select`, `option`, `optgroup`
- `button`, `datalist`, `output`

### Tables
- `table`, `caption`, `colgroup`, `col`
- `thead`, `tbody`, `tfoot`, `tr`, `th`, `td`

### Media
- `img`, `audio`, `video`, `source`, `track`
- `picture`, `canvas`, `svg`
- `iframe`, `embed`, `object`, `param`

### Interactive
- `details`, `summary`, `dialog`
- `menu`, `menuitem`
- `progress`, `meter`

### Other
- `br`, `hr`, `wbr`
- `map`, `area`
- `noscript`, `template`, `slot`

## Extension Methods

### Global Attributes (all elements)
- `.id(string)` - Element ID
- `.@class(string)` - CSS classes
- `.style(string)` - Inline styles
- `.title(string)` - Tooltip text
- `.lang(string)` - Language
- `.dir(string)` - Text direction
- `.hidden()` - Hide element
- `.draggable()` - Make draggable
- `.contenteditable()` - Make editable
- `.spellcheck()` - Enable spellcheck
- `.tabindex(string)` - Tab order

### Data & Accessibility
- `.data(name, value)` - Data attributes
- `.role(string)` - ARIA role
- `.arialabel(string)` - ARIA label
- `.ariadescribedby(string)` - ARIA description
- `.ariahidden(string)` - ARIA hidden

### Events
- `.onclick(string)` - Click handler
- `.onchange(string)` - Change handler
- `.onsubmit(string)` - Submit handler
- `.onfocus(string)` - Focus handler
- `.onblur(string)` - Blur handler

### htmx Attributes
- `.hx_get(url)` - GET request
- `.hx_post(url)` - POST request
- `.hx_put(url)` - PUT request
- `.hx_delete(url)` - DELETE request
- `.hx_target(selector)` - Response target
- `.hx_swap(HxSwap)` - Swap strategy
- `.hx_trigger(HxTrigger)` - Event trigger
- `.hx_confirm(message)` - Confirmation
- `.hx_boost(bool)` - Progressive enhancement
- `.hx_indicator(selector)` - Loading indicator

## Rendering

```csharp
// Render to HTML string
string html = Renderer.Render(node);

// Direct element rendering
string html = element.Render();
```

## C# Reserved Keywords

Use `@` prefix for C# reserved keywords:

- `Html.@base()` - base tag
- `Html.@object()` - object tag
- `Html.@var()` - var tag
- `.@class()` - class attribute
- `.@for()` - for attribute
- `.@readonly()` - readonly attribute
- `.@checked()` - checked attribute
- `.@default()` - default attribute
- `.@async()` - async attribute
- `Html.@if()` - conditional rendering
- `Html.@foreach()` - loop rendering

## Requirements

- .NET Standard 2.0 or higher
- Compatible with:
  - .NET Framework 4.6.1+
  - .NET Core 2.0+
  - .NET 5.0+

## License

MIT

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Related Projects

- [htmx](https://htmx.org/) - High power tools for HTML
- [Bootstrap](https://getbootstrap.com/) - CSS framework that pairs well with FluentHtml