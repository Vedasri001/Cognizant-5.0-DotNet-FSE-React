# Digital Nurture 5.0 - DotNet FSE Upskilling Notes
# MODULE 1: FRONTEND FUNDAMENTALS

# 1. HTML5

## 1.1 Introduction to HTML

**What is HTML?**
HTML (HyperText Markup Language) is the standard markup language used to structure content on the web. It is not a programming language. it has no logic, loops, or conditions. It simply describes the structure of a document using elements (tags).

**Need and benefits of HTML5:**
- Native support for audio/video without plugins like Flash
- New semantic elements (`<header>`, `<footer>`, `<article>`, `<section>`, `<nav>`) that describe content meaning, not just appearance
- Built-in APIs: Geolocation, Web Storage, Drag and Drop, Canvas
- Improved form controls (date pickers, email/url validation, etc.)
- Better error handling - browsers are more forgiving and consistent with HTML5 parsing rules

**Basic structure of an HTML5 document:**
```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Page Title</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <h1>Hello World</h1>
    <script src="script.js"></script>
</body>
</html>
```

**`<!DOCTYPE html>`** Tells the browser to render the page in "standards mode" using HTML5 rules. Without it, browsers fall back to "quirks mode," which can cause inconsistent rendering across browsers. It is not an HTML tag; it's an instruction to the browser.

**Character encoding** `<meta charset="UTF-8">` declares the character set, ensuring special characters (currency symbols, accented letters, emojis) display correctly. UTF-8 is the universal standard and supports virtually all characters/languages.

**`<script>` tag** Embeds or links JavaScript.
```html
<script src="app.js"></script>      <!-- external file -->
<script>console.log("inline");</script>  <!-- inline script -->
```
Placing `<script>` just before `</body>` (rather than in `<head>`) is a common best practice it ensures the HTML content loads first, so the page isn't blocked waiting for JS to download/execute.

**`<link>` tag** Used to link external resources, most commonly stylesheets:
```html
<link rel="stylesheet" href="style.css">
```
It's a self-closing, empty element (no closing tag needed) and always lives in `<head>`.

**Comments in HTML:**
```html
<!-- This is a comment and is not rendered by the browser -->
```
Useful for leaving notes for yourself/teammates or temporarily disabling a block of markup.

**BOM vs DOM:**
- **BOM (Browser Object Model):** Represents the browser window itself objects like `window`, `navigator`, `screen`, `location`, `history`. It lets JavaScript interact with the browser (e.g., `window.alert()`, `window.location.href`).
- **DOM (Document Object Model):** Represents the HTML document as a tree of objects/nodes, where each HTML element becomes a node that JavaScript can read or modify (e.g., `document.getElementById()`). The DOM is actually a property of the BOM's `window` object (`window.document`).

| | BOM | DOM |
|---|---|---|
| Represents | The browser window | The HTML document content |
| Root object | `window` | `document` |
| Example | `window.history.back()` | `document.querySelector('h1')` |

---

## 1.2 Getting Started Tools

**VS Code features relevant to HTML development:**
- IntelliSense (auto-complete for tags/attributes)
- Live Server extension for auto-refreshing browser previews
- Emmet abbreviations (e.g., typing `div.container>ul>li*3` and pressing Tab expands to a full nested structure)
- Integrated terminal and Git support

**Google Chrome DevTools:**
- **Elements panel:** Inspect and live-edit the DOM and CSS
- **Console panel:** Run JavaScript, view errors/logs
- **Network panel:** Monitor HTTP requests, response times, payload sizes
- **Sources panel:** Set breakpoints and debug JavaScript step by step
- Opened via right-click -> "Inspect", or F12 / Ctrl+Shift+I

---

## 1.3 Elements and Attributes

**Formatting tags:**
| Tag | Purpose |
|---|---|
| `<b>` / `<strong>` | Bold text (`<strong>` also conveys semantic importance) |
| `<i>` / `<em>` | Italic text (`<em>` conveys semantic emphasis) |
| `<mark>` | Highlighted text |
| `<small>` | Smaller text |
| `<sub>` / `<sup>` | Subscript / superscript |
| `<br>` | Line break |
| `<hr>` | Horizontal rule/divider |

`<strong>` and `<em>` are preferred over `<b>` and `<i>` because they carry semantic meaning that's useful for accessibility tools (screen readers), while `<b>`/`<i>` are purely visual.

**Lists:**
```html
<ul>                  <!-- unordered list (bullets) -->
    <li>Item</li>
</ul>

<ol>                  <!-- ordered list (numbers) -->
    <li>Step 1</li>
</ol>

<dl>                   <!-- description list -->
    <dt>HTML</dt>
    <dd>HyperText Markup Language</dd>
</dl>
```

**Tables:**
```html
<table>
    <thead>
        <tr><th>Name</th><th>Age</th></tr>
    </thead>
    <tbody>
        <tr><td>Alice</td><td>22</td></tr>
    </tbody>
</table>
```
`<th>` = header cell (bold, centered by default); `<td>` = data cell. `colspan` and `rowspan` attributes merge cells across columns/rows.

**Forms and Input tags:**
```html
<form action="/submit" method="POST">
    <label for="email">Email:</label>
    <input type="email" id="email" name="email" required>
    <input type="password" name="pwd">
    <input type="submit" value="Send">
</form>
```
- `method="GET"` appends data to the URL (visible, used for non-sensitive retrieval requests); `method="POST"` sends data in the request body (used for sensitive data or large payloads).
- `<label for="...">` improves accessibility by linking the label text to its input - clicking the label focuses the input.

**Images:**
```html
<img src="photo.jpg" alt="Description of photo" width="300" height="200">
```
`alt` is mandatory for accessibility (read aloud by screen readers) and displays if the image fails to load.

**Styles attribute:**
```html
<p style="color: red; font-size: 18px;">Inline-styled text</p>
```
Inline styles override embedded/external CSS due to higher specificity, but are discouraged for maintainability - better to use external CSS files.

**`placeholder` attribute:** Shows greyed-out hint text inside an input until the user types something; it is NOT a substitute for a `<label>` (placeholder text disappears on focus/typing, so it shouldn't carry essential instructions).

**Inline vs Block elements:**
| | Block | Inline |
|---|---|---|
| Starts on new line | Yes | No |
| Takes full width | Yes (by default) | No - only as wide as content |
| Can set width/height | Yes | No (ignored unless `display` is changed) |
| Examples | `<div>`, `<p>`, `<h1>`-`<h6>`, `<ul>`, `<table>` | `<span>`, `<a>`, `<strong>`, `<img>` |

**`id` vs `class` attribute:**
| | `id` | `class` |
|---|---|---|
| Uniqueness | Must be unique per page (one element only) | Can be reused on multiple elements |
| CSS selector | `#myId { }` | `.myClass { }` |
| JS selector | `document.getElementById('myId')` | `document.getElementsByClassName('myClass')` |
| CSS specificity | Higher | Lower |
| Use case | Targeting one specific element (e.g., a unique header) | Styling a group of similar elements (e.g., all buttons) |

---

## 1.4 Navigation

**`<nav>` tag:** A semantic HTML5 element that wraps a block of navigation links (main menu, breadcrumbs, table of contents). It doesn't add any default styling - its value is purely semantic, helping screen readers and search engines identify navigation blocks.

```html
<nav>
    <a href="#home">Home</a>
    <a href="#about">About</a>
    <a href="#contact">Contact</a>
</nav>
```

**Hyperlinks:**
```html
<a href="https://example.com">External link</a>
<a href="page2.html">Relative link to another page</a>
<a href="#section2">Jump to a section on the same page</a>
<a href="mailto:someone@email.com">Email link</a>
```

**Reference to intermediate/specific sections:** Using an `id` attribute on a target element and linking to it with `#id`:
```html
<a href="#chapter2">Go to Chapter 2</a>
...
<h2 id="chapter2">Chapter 2</h2>
```
This is how "Table of Contents" jump links and "Back to top" buttons work — no JavaScript required.

---

## 1.5 Events in HTML

Events let HTML elements respond to user actions. While modern best practice is to attach event listeners in JavaScript (`addEventListener`), HTML5 also supports inline event attributes.

| Event | Fires when |
|---|---|
| `onclick` | Element is clicked |
| `ondblclick` | Element is double-clicked |
| `onchange` | An input/select's value changes AND loses focus |
| `onblur` | Element loses focus |
| `onfocus` | Element gains focus |
| `onload` | Page/resource finishes loading |
| `onbeforeunload` | Just before the user leaves/closes the page (often used for "unsaved changes" warnings) |
| `onkeydown` / `onkeyup` | A key is pressed/released |
| `onmouseover` / `onmouseout` | Mouse enters/leaves an element |
| `oncanplay` | Media (audio/video) has enough data to start playing |
| `onsubmit` | A form is submitted |

```html
<button onclick="alert('Clicked!')">Click Me</button>
```

**`onchange` vs `oninput`:** `onchange` fires only after the element loses focus (e.g., tabbing out of a text box); `oninput` fires immediately on every keystroke. For live validation (e.g., a character counter), `oninput` is preferred.

---

## 1.6 Web Forms 2.0

HTML5 introduced several new `<input>` types and attributes that add built-in browser validation, removing the need for custom JavaScript validation in many cases.

**New input types:**
```html
<input type="email">      <!-- validates email format -->
<input type="url">        <!-- validates URL format -->
<input type="number" min="1" max="10">
<input type="date">
<input type="range" min="0" max="100">
<input type="color">
<input type="tel">
<input type="search">
```

**`<output>` element:** Represents the result of a calculation, often used with JS/range sliders:
```html
<input type="range" id="a" oninput="result.value = a.value">
<output name="result" for="a">0</output>
```

**Key attributes:**
- `placeholder` - hint text inside the field
- `autofocus` - automatically focuses this field when the page loads (only one per page)
- `required` - prevents form submission until the field is filled

```html
<input type="text" placeholder="Enter your name" autofocus required>
```

---

## 1.7 Web Storage

HTML5 Web Storage lets you store key-value data in the browser, as an alternative to cookies. It doesn't get sent to the server with every HTTP request (unlike cookies), making it faster and more efficient.

| | `localStorage` | `sessionStorage` |
|---|---|---|
| Lifespan | Persists even after browser is closed | Cleared when the tab/browser is closed |
| Scope | Shared across all tabs of the same origin | Limited to a single tab |
| Storage limit | ~5-10MB | ~5-10MB |

```javascript
// Storing
localStorage.setItem("username", "vedasri");
sessionStorage.setItem("tempData", "123");

// Retrieving
let user = localStorage.getItem("username");

// Removing
localStorage.removeItem("username");

// Clear all
localStorage.clear();
```

Both only store strings - to store objects, use `JSON.stringify()` before saving and `JSON.parse()` after retrieving:
```javascript
localStorage.setItem("user", JSON.stringify({name: "Vedasri", age: 21}));
let user = JSON.parse(localStorage.getItem("user"));
```

---

## 1.8 Web SQL Database

Web SQL was an HTML5 API for client-side relational databases inside the browser using SQL syntax. It is **deprecated** and not recommended for new projects (the W3C abandoned the spec; modern browsers favor IndexedDB instead) — but it remains in the DN 5.0 syllabus as a legacy concept.

```javascript
let db = openDatabase("mydb", "1.0", "Test DB", 2 * 1024 * 1024);

db.transaction(function (tx) {
    tx.executeSql("CREATE TABLE IF NOT EXISTS Users (id unique, name)");
    tx.executeSql("INSERT INTO Users (id, name) VALUES (1, 'Vedasri')");
});
```
- `openDatabase()` - creates or opens a database
- `transaction()` - runs a set of SQL statements as an atomic unit
- `executeSql()` - runs an individual SQL query within the transaction

---

## 1.9 Geolocation API

Lets a web page request the user's physical location (with their permission).

```javascript
if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition, showError);
} else {
    console.log("Geolocation not supported by this browser.");
}

function showPosition(position) {
    console.log("Latitude: " + position.coords.latitude);
    console.log("Longitude: " + position.coords.longitude);
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            console.log("User denied location access.");
            break;
        case error.POSITION_UNAVAILABLE:
            console.log("Location unavailable.");
            break;
        case error.TIMEOUT:
            console.log("Request timed out.");
            break;
    }
}
```

**Position Options:**
```javascript
navigator.geolocation.getCurrentPosition(showPosition, showError, {
    enableHighAccuracy: true,  // use GPS if available (more battery)
    timeout: 5000,             // max wait time in ms
    maximumAge: 0              // don't use a cached position
});
```

**`watchPosition()`** - like `getCurrentPosition()` but continuously tracks location changes (e.g., for live map tracking).

---
---

# 2. CSS3

## 2.1 Introduction to CSS

**What is CSS?** CSS (Cascading Style Sheets) controls the visual presentation of HTML — colors, layout, fonts, spacing - separating content (HTML) from design (CSS).

**Need and benefits:**
- Separation of concerns — content and design are decoupled, making both easier to maintain
- Reusability — one stylesheet can style many pages
- Consistency — uniform look and feel across a site
- Responsive design — adapt layouts to different screen sizes

**CSS Syntax:**
```css
selector {
    property: value;
}
```
Example:
```css
p {
    color: blue;
    font-size: 16px;
}
```

**CSS Comments:**
```css
/* This is a CSS comment */
```

**Three ways to include CSS:**

1. **Inline** — `style` attribute directly on an element. Highest specificity, but hardest to maintain (mixes content and style).
```html
<p style="color: red;">Text</p>
```

2. **Embedded (Internal)** — `<style>` block inside `<head>`. Good for single-page styling.
```html
<head>
  <style>
    p { color: red; }
  </style>
</head>
```

3. **External** — separate `.css` file linked via `<link>`. Best practice for any multi-page site — enables caching and reuse.
```html
<link rel="stylesheet" href="styles.css">
```

**Cascade order (which style wins when multiple rules conflict):**
Inline styles > ID selectors > Class/attribute/pseudo-class selectors > Element selectors, with `!important` overriding all of the above (use sparingly).

---

## 2.2 CSS3 Selectors

| Selector | Syntax | Matches |
|---|---|---|
| Universal | `* { }` | All elements |
| Element type | `p { }` | All `<p>` elements |
| ID | `#header { }` | The element with `id="header"` |
| Class | `.btn { }` | All elements with `class="btn"` |
| Grouping | `h1, h2, h3 { }` | All listed elements (share the same rule) |
| Descendant | `div p { }` | All `<p>` inside any `<div>` |
| Child | `div > p { }` | `<p>` that are **direct** children of `<div>` |
| Attribute | `input[type="text"] { }` | Inputs with `type="text"` |
| Pseudo-class | `a:hover { }` | Links when hovered |
| Pseudo-element | `p::first-line { }` | The first line of a paragraph |

**Specificity** determines which rule wins when multiple selectors match the same element. Roughly: inline (1000) > ID (100) > class/attribute/pseudo-class (10) > element/pseudo-element (1). Higher specificity wins regardless of order in the file.

---

## 2.3 Styling

**Color:**
```css
color: red;                  /* named color */
color: #ff0000;              /* hex */
color: rgb(255, 0, 0);       /* RGB */
color: rgba(255, 0, 0, 0.5); /* RGB with alpha/transparency */
color: hsl(0, 100%, 50%);    /* hue, saturation, lightness */
```

**Background:**
```css
background-color: #f0f0f0;
background-image: url('bg.jpg');
background-repeat: no-repeat;
background-size: cover;
background-position: center;
```

**Fonts:**
```css
font-family: 'Arial', sans-serif;  /* fallback fonts listed after the preferred one */
font-size: 16px;
font-weight: bold;       /* or 100–900 */
font-style: italic;
```

**Text:**
```css
text-align: center;
text-decoration: underline;
text-transform: uppercase;
line-height: 1.5;
letter-spacing: 1px;
```

**Links — pseudo-classes (must be declared in this order, often remembered as "LoVe HAte"):**
```css
a:link { color: blue; }       /* unvisited link */
a:visited { color: purple; }  /* visited link */
a:hover { color: orange; }    /* mouse over */
a:active { color: red; }      /* being clicked */
```

**Lists:**
```css
ul {
    list-style-type: square;  /* disc, circle, square, none */
    list-style-position: inside;
}
```

**Tables:**
```css
table { border-collapse: collapse; width: 100%; }
th, td { border: 1px solid #ccc; padding: 8px; }
tr:nth-child(even) { background-color: #f2f2f2; }  /* zebra striping */
```

---

## 2.4 The CSS Box Model

Every HTML element is treated as a rectangular box made of four layers, from inside out:

```
┌─────────────────────────────┐
│           Margin             │ ← space outside the border (transparent)
│  ┌─────────────────────┐    │
│  │       Border          │    │ ← visible edge
│  │  ┌───────────────┐  │    │
│  │  │    Padding      │  │    │ ← space between content and border
│  │  │  ┌─────────┐  │  │    │
│  │  │  │ Content │  │  │    │ ← actual text/image
│  │  │  └─────────┘  │  │    │
│  │  └───────────────┘  │    │
│  └─────────────────────┘    │
└─────────────────────────────┘
```

```css
div {
    width: 200px;
    padding: 20px;
    border: 5px solid black;
    margin: 10px;
}
```

**`box-sizing` property** — controls how total width/height is calculated:
- `content-box` (default): `width`/`height` apply only to content; padding and border are ADDED on top (total width = 200 + 2×20 + 2×5 = 250px in the example above).
- `border-box`: `width`/`height` include padding and border (total width stays exactly 200px — padding/border eat into the content area instead). Most developers set `* { box-sizing: border-box; }` globally for predictable sizing.

**Margin vs Padding vs Border:**
| | Margin | Padding | Border |
|---|---|---|---|
| Location | Outside the border | Inside the border, around content | Between margin and padding |
| Transparent | Yes | Yes | No — has its own style/color |
| Background color applies | No | Yes | N/A |
| Use case | Spacing between elements | Spacing within an element | Visual separation/framing |

**Margin collapsing:** When two block elements are stacked vertically, their top/bottom margins collapse into a single margin (the larger of the two), rather than adding together. This is a common CSS "gotcha."

**Outline vs Border:**
- `outline` is drawn outside the border and does NOT take up layout space (doesn't affect element size/position of neighbors); commonly used for focus indicators (`:focus { outline: 2px solid blue; }`).
- `border` takes up space and is part of the box model.

**`visibility` vs `display`:**
| | `visibility: hidden` | `display: none` |
|---|---|---|
| Element removed from layout? | No — space is still reserved | Yes — completely removed, other elements shift to fill the gap |
| Can still be clicked/interacted with? | No | No |
| Use case | Hide but preserve layout (e.g., loading placeholder) | Hide completely (e.g., collapsed menu) |

**Multiple Columns:**
```css
.article {
    column-count: 3;
    column-gap: 20px;
    column-rule: 1px solid #ccc;
}
```
Splits text content into newspaper-style columns automatically.

---

## 2.5 Media Queries & Responsive Web Design (RWD)

**Responsive Web Design** is the practice of building layouts that adapt to different screen sizes (mobile, tablet, desktop) using flexible grids, flexible images, and media queries — rather than building separate sites for each device.

**Media Queries** apply CSS rules conditionally based on device characteristics (most commonly viewport width):

```css
/* Default: mobile styles (mobile-first approach) */
.container { width: 100%; }

/* Tablet and up */
@media (min-width: 768px) {
    .container { width: 750px; }
}

/* Desktop and up */
@media (min-width: 1024px) {
    .container { width: 970px; }
}
```

**Mobile-first vs Desktop-first:**
- **Mobile-first:** Write base styles for small screens, then use `min-width` media queries to add complexity as screens get larger. This is the modern best practice — most traffic is mobile, and it forces simpler, more performant base styles.
- **Desktop-first:** Write base styles for large screens, then use `max-width` queries to simplify for smaller screens. Older approach, generally discouraged today.

**The viewport meta tag** (essential for RWD to work on actual mobile devices):
```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```
Without this, mobile browsers render the page at a default desktop width (e.g., 980px) and then scale it down, making media queries behave incorrectly.

**Common RWD techniques:**
- Fluid grids using `%` or `fr` (CSS Grid) instead of fixed `px` widths
- Flexible images: `img { max-width: 100%; height: auto; }`
- `flexbox` and `CSS Grid` for layout instead of floats
- `rem`/`em` units instead of `px` for font sizes, so text scales with user/browser settings


---
---

# 3. JAVASCRIPT

## 3.1 Introduction to JavaScript

**What is JavaScript?** JavaScript (JS) is a dynamic, interpreted, single-threaded scripting language originally designed to add interactivity to web pages. It now runs both in browsers (client-side) and on servers (Node.js).

**Key characteristics:**
- **Dynamically typed** — variable types are determined at runtime, not declared upfront
- **Interpreted** (technically JIT-compiled in modern engines like V8) — no separate compilation step before running
- **Single-threaded with an event loop** — executes one operation at a time, but uses asynchronous callbacks to handle I/O without blocking
- **Prototype-based OOP** — objects inherit directly from other objects, not classes (though ES6 `class` syntax provides a familiar syntax on top of this)

**Setting up a development environment:**
- Any modern browser (has a built-in JS engine + console)
- VS Code with the "Live Server" extension for quick testing
- Node.js for running JS outside the browser (server-side, CLI tools)

```html
<script src="app.js"></script>  <!-- linking external JS -->
```

---

## 3.2 JavaScript Basics

**Syntax and Statements:**
JavaScript statements end with a semicolon (optional due to Automatic Semicolon Insertion, but recommended for clarity). Code is case-sensitive.

```javascript
let x = 5;
console.log(x);
```

**Data Types:**

JavaScript has two categories:

**Primitive types** (immutable, compared by value):
| Type | Example |
|---|---|
| `number` | `42`, `3.14` (JS has only one numeric type — no separate int/float) |
| `string` | `"hello"`, `'hello'`, `` `hello` `` |
| `boolean` | `true`, `false` |
| `undefined` | A variable declared but not assigned a value |
| `null` | Intentional absence of a value |
| `bigint` | For integers larger than `Number.MAX_SAFE_INTEGER` |
| `symbol` | Unique, immutable identifier (often used as object property keys) |

**Reference type:**
| Type | Example |
|---|---|
| `object` | `{}`, `[]`, functions, dates — all are objects under the hood |

```javascript
let age = 25;                    // number
let name = "Vedasri";            // string
let isActive = true;             // boolean
let car;                         // undefined
let result = null;               // null
let person = { name: "A", age: 21 }; // object
let arr = [1, 2, 3];             // object (array)
```

**`typeof` operator:**
```javascript
typeof 42;           // "number"
typeof "hi";          // "string"
typeof undefined;     // "undefined"
typeof null;          // "object"  -- famous JS quirk/bug, kept for backward compatibility
typeof {};            // "object"
typeof [];            // "object"  -- arrays are objects; use Array.isArray() to check specifically
```

**`var` vs `let` vs `const`:**
| | `var` | `let` | `const` |
|---|---|---|---|
| Scope | Function-scoped | Block-scoped | Block-scoped |
| Re-declaration | Allowed | Not allowed | Not allowed |
| Re-assignment | Allowed | Allowed | Not allowed |
| Hoisting | Hoisted, initialized as `undefined` | Hoisted but in "temporal dead zone" (error if used before declaration) | Same as `let` |

`const` doesn't make objects/arrays immutable — it only prevents reassigning the variable itself:
```javascript
const arr = [1, 2, 3];
arr.push(4);     // OK — mutating contents is allowed
arr = [5, 6];    // Error — reassigning the variable is not allowed
```

**Operators:**

| Category | Operators |
|---|---|
| Arithmetic | `+ - * / % **` (exponent) |
| Assignment | `= += -= *= /=` |
| Comparison | `== != === !== > < >= <=` |
| Logical | `&& \|\| !` |
| Ternary | `condition ? valIfTrue : valIfFalse` |
| Nullish coalescing | `??` (returns right side only if left is `null`/`undefined`) |
| Optional chaining | `?.` (safely accesses nested properties without throwing if intermediate is null/undefined) |

**`==` vs `===` (critical interview topic):**
- `==` (loose equality) performs **type coercion** before comparing — `"5" == 5` is `true`.
- `===` (strict equality) compares both **value and type** — no coercion — `"5" === 5` is `false`.
- Best practice: always use `===`/`!==` to avoid unexpected coercion bugs.

```javascript
console.log("5" == 5);    // true  (coerced)
console.log("5" === 5);   // false (different types)
console.log(null == undefined);  // true
console.log(null === undefined); // false
```

---

## 3.3 Control Flow

**Conditional Statements:**
```javascript
if (age >= 18) {
    console.log("Adult");
} else if (age >= 13) {
    console.log("Teen");
} else {
    console.log("Child");
}

switch (day) {
    case "Mon":
        console.log("Start of week");
        break;
    case "Fri":
        console.log("Almost weekend");
        break;
    default:
        console.log("Midweek");
}
```
`break` is essential in `switch` — without it, execution "falls through" into the next case.

**Loops:**
```javascript
for (let i = 0; i < 5; i++) { console.log(i); }

let i = 0;
while (i < 5) { console.log(i); i++; }

let j = 0;
do { console.log(j); j++; } while (j < 5);  // runs at least once, even if condition is false

let arr = [1, 2, 3];
for (let val of arr) { console.log(val); }       // iterates VALUES (arrays, strings, maps, sets)
for (let key in {a: 1, b: 2}) { console.log(key); } // iterates KEYS (objects)
```

**Error Handling:**
```javascript
try {
    let result = riskyOperation();
} catch (error) {
    console.error("Something went wrong:", error.message);
} finally {
    console.log("This always runs, success or failure.");
}

throw new Error("Custom error message");
```

---

## 3.4 Functions and Scope

**Function basics — three ways to define a function:**
```javascript
// Function declaration (hoisted — can be called before its definition in the code)
function greet(name) {
    return "Hello, " + name;
}

// Function expression (NOT hoisted)
const greet2 = function(name) {
    return "Hello, " + name;
};

// Arrow function (ES6, NOT hoisted, no own 'this')
const greet3 = (name) => "Hello, " + name;
```

**Scope and Closures:**

**Scope** determines where a variable is accessible:
- **Global scope:** accessible everywhere
- **Function scope:** `var` is scoped to the entire function it's declared in
- **Block scope:** `let`/`const` are scoped to the nearest `{ }` block (if, for, while, etc.)

**Closure:** A function that "remembers" variables from its outer (lexical) scope even after that outer function has finished executing.

```javascript
function makeCounter() {
    let count = 0;          // private variable
    return function () {
        count++;             // inner function "closes over" count
        return count;
    };
}

const counter = makeCounter();
console.log(counter()); // 1
console.log(counter()); // 2 — count persisted between calls!
```
**Why closures matter:** They enable data privacy (simulating private variables before JS had native private class fields) and are the foundation of patterns like the module pattern, memoization, and callback-based async code.

**Higher-Order Functions:** Functions that either accept another function as an argument, return a function, or both.

```javascript
// Accepts a function as argument
function processArray(arr, callback) {
    return arr.map(callback);
}
processArray([1, 2, 3], x => x * 2);  // [2, 4, 6]

// Built-in higher-order functions: map, filter, reduce, forEach
[1, 2, 3].map(x => x * 2);              // [2, 4, 6]
[1, 2, 3].filter(x => x > 1);           // [2, 3]
[1, 2, 3].reduce((acc, x) => acc + x, 0); // 6
```

---

## 3.5 Objects and the DOM

**Objects in JavaScript:**
```javascript
const person = {
    name: "Vedasri",
    age: 21,
    greet() {                  // method shorthand
        console.log("Hi, I'm " + this.name);
    }
};

person.greet();             // dot notation
console.log(person["age"]); // bracket notation — needed for dynamic keys
```

**`this` keyword:** Refers to the object that is currently executing the function. Its value depends on HOW a function is called, not where it's defined:
- In a regular function called as a method (`obj.method()`), `this` = `obj`.
- In a standalone function call, `this` = `undefined` (strict mode) or the global object.
- **Arrow functions do NOT have their own `this`** — they inherit `this` from their enclosing lexical scope. This is why arrow functions are often preferred for callbacks inside methods.

**JavaScript Prototypes:** Every JS object has an internal link to another object called its **prototype**, from which it inherits properties/methods. This is the basis of **prototypal inheritance**.
```javascript
function Animal(name) { this.name = name; }
Animal.prototype.speak = function () { console.log(this.name + " makes a sound."); };

const dog = new Animal("Rex");
dog.speak();  // "Rex makes a sound." — speak() is found via the prototype chain, not on dog itself
```

**The DOM (Document Object Model):** A tree-structured representation of the HTML page that JavaScript can read and manipulate.

```javascript
// Selecting elements
document.getElementById("myId");
document.getElementsByClassName("myClass");  // returns a live HTMLCollection
document.querySelector(".myClass");           // returns the FIRST match (CSS selector syntax)
document.querySelectorAll(".myClass");        // returns ALL matches (NodeList)

// Modifying elements
let el = document.querySelector("#title");
el.textContent = "New Text";        // sets plain text (safe — no HTML parsing)
el.innerHTML = "<b>Bold</b>";       // sets HTML content (be careful — XSS risk with user input)
el.style.color = "blue";
el.classList.add("active");
el.classList.remove("hidden");
el.classList.toggle("open");

// Creating/removing elements
let newDiv = document.createElement("div");
newDiv.textContent = "I'm new";
document.body.appendChild(newDiv);
newDiv.remove();
```

**Event Handling:**
```javascript
let btn = document.querySelector("#myBtn");
btn.addEventListener("click", function (event) {
    console.log("Button clicked!", event.target);
});
```
`addEventListener` is preferred over inline `onclick=""` HTML attributes because it cleanly separates JS from HTML and allows attaching multiple listeners to the same element/event.

**Event Bubbling:** When an event fires on an element, it also "bubbles up" and fires on all its ancestor elements. `event.stopPropagation()` stops this bubbling. **Event delegation** uses bubbling intentionally — attaching one listener to a parent to handle events from many children (efficient for dynamic lists):
```javascript
document.querySelector("#list").addEventListener("click", function (e) {
    if (e.target.tagName === "LI") {
        console.log("Clicked item:", e.target.textContent);
    }
});
```

---

## 3.6 Arrays and Array Methods

**Array basics:**
```javascript
let fruits = ["apple", "banana", "cherry"];
fruits[0];          // "apple"
fruits.length;       // 3
fruits.push("date"); // adds to end
fruits.pop();         // removes from end
fruits.shift();       // removes from start
fruits.unshift("x");  // adds to start
```

**Important array methods (very commonly asked in interviews):**

| Method | Purpose | Mutates original? |
|---|---|---|
| `map()` | Transforms each element, returns a new array | No |
| `filter()` | Returns a new array with elements passing a test | No |
| `reduce()` | Reduces array to a single accumulated value | No |
| `forEach()` | Runs a function on each element (no return value) | No |
| `find()` | Returns the FIRST matching element (or `undefined`) | No |
| `findIndex()` | Returns the index of the first match (or -1) | No |
| `includes()` | Returns `true`/`false` if value exists | No |
| `sort()` | Sorts elements (default: as strings!) | **Yes** |
| `splice()` | Adds/removes elements at a specific index | **Yes** |
| `slice()` | Extracts a portion (start, end) | No |
| `concat()` | Merges arrays | No |
| `join()` | Converts array to string with separator | No |

```javascript
let nums = [5, 1, 4, 2, 3];
nums.sort();                          // [1, 2, 3, 4, 5] for numbers this happens to work
nums.sort((a, b) => a - b);           // CORRECT way for numeric sort (ascending)
nums.sort((a, b) => b - a);           // descending

// splice vs slice
let arr = [1, 2, 3, 4, 5];
arr.splice(1, 2);          // removes 2 elements starting at index 1 → arr is now [1, 4, 5] (MUTATES)
let copy = arr.slice(1, 3); // returns [4, 5] without changing arr (NON-MUTATING)
```

---

## 3.7 Asynchronous JavaScript

**Why asynchronous programming matters:** JavaScript is single-threaded — it can only do one thing at a time. Asynchronous patterns let long-running operations (network requests, file reads, timers) happen "in the background" without freezing the rest of the page.

**Callbacks:**
```javascript
function fetchData(callback) {
    setTimeout(() => {
        callback("Data received");
    }, 1000);
}
fetchData((result) => console.log(result));
```

**Callback Hell:** Nesting multiple callbacks leads to deeply indented, hard-to-read/maintain code:
```javascript
getUser(id, (user) => {
    getOrders(user.id, (orders) => {
        getOrderDetails(orders[0].id, (details) => {
            console.log(details); // deeply nested "pyramid of doom"
        });
    });
});
```

**Promises:** An object representing the eventual completion (or failure) of an async operation. A Promise has 3 states: `pending`, `fulfilled`, `rejected`.

```javascript
function fetchData() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            const success = true;
            if (success) resolve("Data loaded");
            else reject("Error loading data");
        }, 1000);
    });
}

fetchData()
    .then(result => console.log(result))
    .catch(error => console.error(error))
    .finally(() => console.log("Done"));
```

**Async/Await (syntactic sugar over Promises, introduced in ES2017):**
```javascript
async function loadData() {
    try {
        const result = await fetchData();   // pauses execution here until the Promise resolves
        console.log(result);
    } catch (error) {
        console.error(error);
    }
}
```
`await` can only be used inside an `async` function. It makes asynchronous code read like synchronous code, which is far easier to follow than chained `.then()` calls or nested callbacks.

**`Promise.all()` vs `Promise.race()`:**
```javascript
Promise.all([p1, p2, p3]);   // waits for ALL to resolve; rejects immediately if ANY rejects
Promise.race([p1, p2, p3]);  // resolves/rejects as soon as the FIRST one settles
```

---

## 3.8 JavaScript ES6+ Features

**`let` and `const`:** Block-scoped alternatives to `var` (see section 3.2).

**Template Literals:** Backtick strings supporting embedded expressions and multi-line text:
```javascript
const name = "Vedasri";
const greeting = `Hello, ${name}! You have ${5 + 3} new messages.`;
const multiLine = `Line 1
Line 2`;
```

**Destructuring:** Unpacks values from arrays/objects into individual variables.
```javascript
// Array destructuring
const [first, second] = [10, 20];

// Object destructuring
const { name, age } = { name: "Vedasri", age: 21 };

// With renaming and defaults
const { name: fullName, country = "India" } = { name: "Vedasri" };
```

**Rest and Spread Operators (both use `...` but do opposite things):**
```javascript
// Rest — collects multiple arguments into an array
function sum(...numbers) {
    return numbers.reduce((a, b) => a + b, 0);
}
sum(1, 2, 3, 4); // 10

// Spread — expands an array/object into individual elements
const arr1 = [1, 2, 3];
const arr2 = [...arr1, 4, 5];      // [1, 2, 3, 4, 5]

const obj1 = { a: 1, b: 2 };
const obj2 = { ...obj1, c: 3 };    // { a: 1, b: 2, c: 3 }
```

**Modules:** ES6 introduced native `import`/`export` for splitting code into reusable files.
```javascript
// math.js
export function add(a, b) { return a + b; }
export default function multiply(a, b) { return a * b; }

// app.js
import multiply, { add } from './math.js';
```

**Default Parameters:**
```javascript
function greet(name = "Guest") {
    console.log(`Hello, ${name}`);
}
greet(); // "Hello, Guest"
```

---

## 3.9 JavaScript in Web Development

**Working with Forms:**
```javascript
document.querySelector("#myForm").addEventListener("submit", function (e) {
    e.preventDefault();  // stops the default full-page-reload form submission
    const formData = new FormData(this);
    console.log(formData.get("email"));
});
```

**AJAX (Asynchronous JavaScript And XML):** A technique for making HTTP requests from JavaScript without reloading the page. Despite the name, modern AJAX almost always uses JSON, not XML.

**Fetch API:** The modern, Promise-based way to make HTTP requests (replacing the older `XMLHttpRequest`):
```javascript
fetch("https://api.example.com/users")
    .then(response => {
        if (!response.ok) throw new Error("Network error");
        return response.json();
    })
    .then(data => console.log(data))
    .catch(error => console.error(error));

// With async/await
async function getUsers() {
    const response = await fetch("https://api.example.com/users");
    const data = await response.json();
    return data;
}

// POST request
fetch("https://api.example.com/users", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ name: "Vedasri", age: 21 })
});
```

---

## 3.10 Debugging and Testing JavaScript

**Debugging Tools:**
- `console.log()`, `console.error()`, `console.warn()`, `console.table()` for inspecting values
- Browser DevTools → Sources panel: set **breakpoints**, step through code line by line, inspect the call stack and variable scope at each point
- `debugger;` statement — pauses execution at that line when DevTools is open

**Testing JavaScript Code:**
- **Unit testing** — testing individual functions in isolation, typically using frameworks like **Jest**, **Mocha**, or **Jasmine**.
```javascript
// Example Jest test
test('adds 1 + 2 to equal 3', () => {
    expect(sum(1, 2)).toBe(3);
});
```
- Helps catch regressions early and documents expected behavior.

---

## 3.11 Introduction to JavaScript Frameworks and Libraries

**Popular JS frameworks/libraries overview:**
| Tool | Type | Notes |
|---|---|---|
| React | Library | Component-based UI library by Meta; uses a Virtual DOM |
| Angular | Framework | Full-featured, opinionated framework by Google; uses TypeScript |
| Vue.js | Framework | Progressive framework, easier learning curve |
| jQuery | Library | Simplifies DOM manipulation and AJAX (legacy but still widely used) |

**Library vs Framework:** A library is a tool YOU call when needed (you control the flow). A framework calls YOUR code ("inversion of control") — it dictates the structure of your application.

**Using jQuery for DOM Manipulation** (bridges into the next topic):
```javascript
$("#myBtn").click(function () {
    $("#title").text("Updated!");
});
```
jQuery dramatically simplified cross-browser DOM manipulation in the pre-ES6 era; modern vanilla JS (`querySelector`, `fetch`, etc.) has closed much of that gap, but jQuery remains common in legacy codebases.


---
---

# 4. BOOTSTRAP 5

## 4.1 Introduction to Bootstrap

**What is Bootstrap?** Bootstrap is the world's most popular open-source CSS/JS framework for building responsive, mobile-first websites quickly, using pre-built components and a grid system instead of writing all CSS from scratch.

**Setting up Bootstrap 5:**
```html
<!-- Via CDN -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
```
Bootstrap 5 dropped the jQuery dependency that Bootstrap 4 had — its JS plugins (modals, dropdowns, etc.) are now written in plain (vanilla) JavaScript.

**Folder/file structure (when using the full package, not CDN):**
```
bootstrap/
├── css/bootstrap.min.css
└── js/bootstrap.bundle.min.js   (includes Popper.js, needed for tooltips/popovers/dropdowns)
```

---

## 4.2 Bootstrap Grid System

Bootstrap's grid is based on **Flexbox**, divided into a **12-column** layout, organized using three levels: **container → row → column**.

```html
<div class="container">
    <div class="row">
        <div class="col-4">Column 1 (4/12 width)</div>
        <div class="col-8">Column 2 (8/12 width)</div>
    </div>
</div>
```

**Container types:**
- `.container` — fixed max-width that changes at each breakpoint
- `.container-fluid` — always 100% width of the viewport

**Responsive breakpoints (column classes change behavior per screen size):**
| Class prefix | Applies from screen width |
|---|---|
| `.col-` | All screens (extra small, default) |
| `.col-sm-` | ≥576px |
| `.col-md-` | ≥768px |
| `.col-lg-` | ≥992px |
| `.col-xl-` | ≥1200px |
| `.col-xxl-` | ≥1400px |

```html
<div class="row">
    <div class="col-12 col-md-6 col-lg-4">
        <!-- full width on mobile, half width on tablet, 1/3 width on desktop -->
    </div>
</div>
```

**Alignment and Reordering:**
```html
<div class="row align-items-center">     <!-- vertical alignment of columns -->
<div class="row justify-content-center">  <!-- horizontal alignment -->
<div class="col order-md-2">              <!-- reorder columns at md breakpoint -->
```

**Responsive Flexbox Utilities:**
```html
<div class="d-flex justify-content-between align-items-center">
    <div>Left</div>
    <div>Right</div>
</div>
```
`d-flex` applies `display: flex`; combined with `justify-content-*` and `align-items-*` utility classes, this replaces a lot of custom flexbox CSS.

---

## 4.3 Bootstrap Components

**Typography:**
```html
<h1 class="display-1">Big Heading</h1>
<p class="lead">A lead paragraph, slightly larger and lighter.</p>
<p class="text-muted">Muted/secondary text.</p>
```

**Forms:**
```html
<form>
    <div class="mb-3">
        <label class="form-label">Email</label>
        <input type="email" class="form-control" placeholder="name@example.com">
    </div>
    <div class="form-check">
        <input class="form-check-input" type="checkbox">
        <label class="form-check-label">Remember me</label>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

**Buttons:**
```html
<button class="btn btn-primary">Primary</button>
<button class="btn btn-outline-danger">Outline Danger</button>
<button class="btn btn-success btn-lg">Large Success</button>
```
Bootstrap's color naming convention (`primary`, `secondary`, `success`, `danger`, `warning`, `info`, `light`, `dark`) is consistent across buttons, alerts, badges, and text utilities.

**Navbars and Navigation:**
```html
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">MySite</a>
        <button class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navMenu">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navMenu">
            <ul class="navbar-nav">
                <li class="nav-item"><a class="nav-link" href="#">Home</a></li>
                <li class="nav-item"><a class="nav-link" href="#">About</a></li>
            </ul>
        </div>
    </div>
</nav>
```
`navbar-expand-lg` means the navbar shows full horizontally on `lg`+ screens and collapses into a hamburger toggle below that.

**Cards:**
```html
<div class="card" style="width: 18rem;">
    <img src="img.jpg" class="card-img-top">
    <div class="card-body">
        <h5 class="card-title">Card Title</h5>
        <p class="card-text">Some quick example text.</p>
        <a href="#" class="btn btn-primary">Go</a>
    </div>
</div>
```
Cards are flexible content containers — a very commonly used Bootstrap component for product listings, profile previews, dashboards, etc.

---

## 4.4 Bootstrap Utilities and Helpers

**Spacing utilities** — pattern: `{property}{sides}-{size}`
- Property: `m` (margin) or `p` (padding)
- Sides: `t` (top), `b` (bottom), `s` (start/left), `e` (end/right), `x` (left+right), `y` (top+bottom), blank (all 4 sides)
- Size: `0`–`5` (increasing scale) or `auto`

```html
<div class="mt-3 pb-2 mx-auto">...</div>
<!-- margin-top: 1rem; padding-bottom: 0.5rem; margin-left/right: auto (centers a fixed-width block) -->
```

**Colors and Backgrounds:**
```html
<p class="text-primary">Primary text</p>
<div class="bg-success text-white p-3">Success background</div>
```

**Display and Visibility:**
```html
<div class="d-none d-md-block">Visible only on md+ screens</div>
<div class="d-block d-md-none">Visible only below md</div>
```

**Borders, Shadows, Rounded corners:**
```html
<div class="border border-primary rounded shadow-sm p-3">Styled box</div>
<img class="rounded-circle" src="avatar.jpg">
```

**Positioning Utilities:**
```html
<div class="position-relative">
    <span class="position-absolute top-0 end-0">Badge</span>
</div>
```

---

## 4.5 Advanced Bootstrap 5 Features

**Bootstrap Icons:**
```html
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.0/font/bootstrap-icons.css">
<i class="bi bi-heart-fill"></i>
```

**Bootstrap 5 JavaScript Plugins (now vanilla JS, no jQuery needed):**
```html
<!-- Modal -->
<button data-bs-toggle="modal" data-bs-target="#myModal">Open Modal</button>
<div class="modal" id="myModal">
    <div class="modal-dialog">
        <div class="modal-content">...</div>
    </div>
</div>
```
Other plugins: Dropdowns, Carousels, Tooltips, Popovers, Toasts, Accordion (Collapse) — all driven by `data-bs-*` attributes, with optional JS API for programmatic control (`new bootstrap.Modal(element)`).

**Customization with Sass:**
Bootstrap is built with Sass, so instead of overriding compiled CSS, you can recompile Bootstrap with your own variable values:
```scss
// custom.scss
$primary: #ff6347;          // override the default blue "primary" color
@import "bootstrap/scss/bootstrap";
```
This is more efficient than fighting CSS specificity with `!important` overrides — it changes the framework's design tokens at the source.

---
---

# 5. jQuery

## 5.1 Introduction to jQuery and its Features

**What is jQuery?** jQuery is a lightweight, "write less, do more" JavaScript library designed to simplify HTML DOM traversal/manipulation, event handling, animation, and AJAX, with built-in cross-browser compatibility.

**Key features:**
- **Simplicity** — complex DOM operations reduced to one-liners
- **Cross-browser support** — historically smoothed over inconsistencies between Internet Explorer, Firefox, Chrome, etc. (less critical today, since modern browsers are far more standardized, but jQuery remains widely used in legacy/enterprise codebases)
- **Chainable methods** — multiple operations can be chained in a single statement
- **Lightweight** — small file size relative to functionality provided
- **Built-in AJAX support** — simplifies asynchronous HTTP requests

---

## 5.2 Basic Components of jQuery

**Including jQuery — Local vs CDN:**
```html
<!-- CDN (recommended — faster, often already cached by the browser from another site) -->
<script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

<!-- Local -->
<script src="js/jquery.min.js"></script>
```

**The `$()` function:** The core of jQuery — both an alias for `jQuery` and a way to select elements (similar to `document.querySelector` but returns a jQuery-wrapped object with extra methods).

```javascript
$(document).ready(function () {
    // code here runs only after the DOM is fully loaded
});

// Shorthand
$(function () {
    // same as above
});
```

```javascript
$("#myId");          // select by ID
$(".myClass");        // select by class
$("p");                // select by tag
$("div.box");          // combined selector
```

**jQuery Methods (getter/setter pattern — same method reads OR writes depending on arguments):**
```javascript
$("#title").text();             // GET text content
$("#title").text("New Text");   // SET text content

$("#box").css("color");          // GET a CSS property
$("#box").css("color", "blue");  // SET a CSS property

$("#input").val();               // GET input value
$("#input").val("default text"); // SET input value

$("#link").attr("href");                // GET attribute
$("#link").attr("href", "page2.html");  // SET attribute
```

---

## 5.3 DOM Manipulation and Events in jQuery

**DOM Manipulation:**
```javascript
$("#box").html("<b>Bold text</b>");   // set inner HTML
$("#box").append("<p>Added at end</p>");
$("#box").prepend("<p>Added at start</p>");
$("#box").remove();                    // removes the element entirely
$("#box").empty();                     // removes all children, keeps the element itself
$("#box").addClass("active");
$("#box").removeClass("hidden");
$("#box").toggleClass("open");
```

**Working with Events:**
```javascript
$("#btn").click(function () {
    console.log("Button clicked");
});

$("#input").on("keyup", function () {
    console.log("Key released, current value:", $(this).val());
});

// .on() is the modern, preferred way — also supports event delegation:
$("#list").on("click", "li", function () {
    console.log("Clicked item:", $(this).text());
});
```
`.on()` with a selector argument (event delegation) handles events on elements that don't exist yet at page load time — important for dynamically added content (e.g., items added via AJAX).

**Event Helpers (shorthand methods for common events):**
| Method | Equivalent to |
|---|---|
| `.click()` | `.on("click", ...)` |
| `.hover()` | `.on("mouseenter mouseleave", ...)` |
| `.submit()` | `.on("submit", ...)` |
| `.change()` | `.on("change", ...)` |
| `.focus()` / `.blur()` | `.on("focus"/"blur", ...)` |

```javascript
$(".menu-item").hover(
    function () { $(this).addClass("highlight"); },   // mouse enters
    function () { $(this).removeClass("highlight"); }  // mouse leaves
);

$("#myForm").submit(function (e) {
    e.preventDefault();
    console.log("Form submitted");
});
```

**Method chaining (a key jQuery efficiency feature):**
```javascript
$("#box")
    .css("color", "blue")
    .slideUp(300)
    .slideDown(300)
    .addClass("highlighted");
```
Because most jQuery methods return the jQuery object itself, you can chain multiple operations in sequence without re-selecting the element each time.


---
---

# MODULE 2: ANSI SQL USING MYSQL

## 6.1 Introduction to ANSI SQL and MySQL

**What is ANSI SQL?** ANSI SQL is the American National Standards Institute's standardized specification for SQL syntax and behavior. It ensures that core SQL commands (`SELECT`, `INSERT`, `JOIN`, etc.) work consistently across different database systems (MySQL, PostgreSQL, Oracle, SQL Server), even though each vendor also adds proprietary extensions on top.

**Importance of Standard SQL:** Without a standard, SQL code written for one database wouldn't be portable to another. ANSI SQL provides a common baseline that developers can rely on across vendors, reducing vendor lock-in and easing the learning curve when switching database systems.

**What is MySQL?** MySQL is one of the world's most popular open-source Relational Database Management Systems (RDBMS), implementing (and extending) ANSI SQL. It's widely used in web applications (the "M" in the classic LAMP stack: Linux, Apache, MySQL, PHP).

---

## 6.2 Data Retrieval with SELECT Statement

**Basic SELECT syntax:**
```sql
SELECT column1, column2 FROM table_name;
SELECT * FROM employees;          -- * selects all columns (avoid in production code — explicit columns are more efficient/maintainable)
```

**Retrieving specific columns:**
```sql
SELECT first_name, salary FROM employees;
```

**Filtering data with WHERE:**
```sql
SELECT * FROM employees WHERE department = 'IT';
SELECT * FROM employees WHERE salary > 50000;
SELECT * FROM employees WHERE hire_date >= '2023-01-01';
```

**Sorting results with ORDER BY:**
```sql
SELECT * FROM employees ORDER BY salary DESC;     -- highest first
SELECT * FROM employees ORDER BY department ASC, salary DESC;  -- multi-column sort
```
`ASC` (ascending) is the default if not specified.

---

## 6.3 Filtering and Sorting Data

**Logical operators in WHERE:**
```sql
SELECT * FROM employees WHERE department = 'IT' AND salary > 60000;
SELECT * FROM employees WHERE department = 'IT' OR department = 'HR';
SELECT * FROM employees WHERE NOT department = 'Sales';
SELECT * FROM employees WHERE department IN ('IT', 'HR', 'Finance');
SELECT * FROM employees WHERE salary BETWEEN 40000 AND 80000;
SELECT * FROM employees WHERE first_name LIKE 'A%';     -- starts with A
SELECT * FROM employees WHERE email LIKE '%@gmail.com';  -- ends with @gmail.com
SELECT * FROM employees WHERE manager_id IS NULL;        -- NULL check (never use = NULL, it always returns unknown/false)
```

**Combining conditions with AND/OR — operator precedence matters:**
```sql
-- AND binds tighter than OR, so use parentheses to be explicit and avoid bugs
SELECT * FROM employees
WHERE department = 'IT' AND (salary > 60000 OR years_experience > 5);
```

**Sorting using multiple columns:**
```sql
SELECT * FROM employees ORDER BY department, salary DESC;
```
This sorts primarily by department (alphabetically), and within each department, by salary descending.

---

## 6.4 Aggregate Functions and Grouping

**Aggregate functions** operate on a set of rows and return a single summary value:
| Function | Purpose |
|---|---|
| `COUNT()` | Number of rows |
| `SUM()` | Total of a numeric column |
| `AVG()` | Average value |
| `MIN()` | Smallest value |
| `MAX()` | Largest value |

```sql
SELECT COUNT(*) FROM employees;
SELECT AVG(salary) FROM employees WHERE department = 'IT';
SELECT MAX(salary), MIN(salary) FROM employees;
```

**GROUP BY clause** — groups rows sharing the same value in specified columns, so aggregate functions compute per-group instead of for the entire table:
```sql
SELECT department, COUNT(*) AS employee_count, AVG(salary) AS avg_salary
FROM employees
GROUP BY department;
```
Every non-aggregated column in the `SELECT` list MUST appear in `GROUP BY` (in standard ANSI SQL / strict MySQL mode), otherwise the result is ambiguous.

**HAVING clause** — filters groups AFTER aggregation (whereas `WHERE` filters rows BEFORE aggregation):
```sql
SELECT department, AVG(salary) AS avg_salary
FROM employees
GROUP BY department
HAVING AVG(salary) > 60000;
```
**Why not use `WHERE` for this?** `WHERE` cannot reference aggregate functions because filtering happens before aggregation occurs — `HAVING` exists specifically to filter post-aggregation results.

**Order of logical execution (important interview question):**
```
FROM → WHERE → GROUP BY → HAVING → SELECT → ORDER BY → LIMIT
```

---

## 6.5 Joins and Subqueries

**INNER JOIN** — returns only rows with matches in both tables:
```sql
SELECT e.name, d.dept_name
FROM employees e
INNER JOIN departments d ON e.dept_id = d.id;
```

**LEFT JOIN** — returns all rows from the left table, plus matched rows from the right (NULL where no match):
```sql
SELECT e.name, d.dept_name
FROM employees e
LEFT JOIN departments d ON e.dept_id = d.id;
-- shows ALL employees, even those without a department assigned
```

**RIGHT JOIN** — mirror of LEFT JOIN; all rows from the right table, matched rows from the left:
```sql
SELECT e.name, d.dept_name
FROM employees e
RIGHT JOIN departments d ON e.dept_id = d.id;
-- shows ALL departments, even those with zero employees
```
(MySQL doesn't support `FULL OUTER JOIN` directly — it's typically simulated with a `UNION` of LEFT and RIGHT JOIN.)

**Self-join** — a table joined with itself, useful for hierarchical data (e.g., employees and their managers, both stored in the same `employees` table):
```sql
SELECT e.name AS employee, m.name AS manager
FROM employees e
LEFT JOIN employees m ON e.manager_id = m.id;
```

**Cross join** — produces the Cartesian product of two tables (every row from table A paired with every row from table B):
```sql
SELECT * FROM colors CROSS JOIN sizes;
-- if colors has 3 rows and sizes has 4 rows, result has 12 rows
```

**Subqueries** — a query nested inside another query.

In `WHERE`:
```sql
SELECT name FROM employees
WHERE salary > (SELECT AVG(salary) FROM employees);
```

In `FROM` (treated as a derived/temporary table):
```sql
SELECT dept_id, avg_sal FROM (
    SELECT dept_id, AVG(salary) AS avg_sal FROM employees GROUP BY dept_id
) AS dept_avg
WHERE avg_sal > 50000;
```

In `SELECT`:
```sql
SELECT name, (SELECT dept_name FROM departments d WHERE d.id = e.dept_id) AS dept
FROM employees e;
```

**Correlated subquery** — a subquery that references a column from the OUTER query, meaning it must be re-evaluated once for EACH row of the outer query (unlike a regular subquery, which runs once independently):
```sql
SELECT name, salary FROM employees e
WHERE salary > (
    SELECT AVG(salary) FROM employees WHERE department = e.department
);
-- finds employees earning more than their OWN department's average
```
Correlated subqueries are conceptually similar to a loop — for performance on large tables, an equivalent `JOIN` is often faster, since the database can frequently optimize joins better than row-by-row correlated execution.

---

## 6.6 Data Modification with INSERT, UPDATE, DELETE

**INSERT:**
```sql
INSERT INTO employees (name, department, salary) VALUES ('Vedasri', 'IT', 55000);

-- Insert multiple rows at once
INSERT INTO employees (name, department, salary) VALUES
    ('A', 'HR', 40000),
    ('B', 'IT', 60000);
```

**UPDATE:**
```sql
UPDATE employees SET salary = 65000 WHERE name = 'Vedasri';

-- ⚠️ Forgetting WHERE updates EVERY row in the table — always double-check before running
UPDATE employees SET department = 'IT';
```

**DELETE:**
```sql
DELETE FROM employees WHERE department = 'Sales';

-- ⚠️ Same danger as UPDATE — no WHERE deletes the entire table's data
DELETE FROM employees;
```
`DELETE` (DML) removes rows one at a time and can be rolled back within a transaction; it's different from `TRUNCATE` (DDL), which instantly removes ALL rows and resets auto-increment counters, and generally cannot be rolled back.

---

## 6.7 Creating and Modifying Tables

**CREATE TABLE:**
```sql
CREATE TABLE employees (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    department VARCHAR(50),
    salary DECIMAL(10, 2),
    hire_date DATE DEFAULT (CURRENT_DATE)
);
```

**ALTER TABLE — modifying structure:**
```sql
ALTER TABLE employees ADD COLUMN email VARCHAR(100);
ALTER TABLE employees DROP COLUMN email;
ALTER TABLE employees MODIFY COLUMN salary DECIMAL(12, 2);
ALTER TABLE employees RENAME COLUMN department TO dept;
ALTER TABLE employees RENAME TO staff;
```

**DROP TABLE — permanently deletes the table and ALL its data:**
```sql
DROP TABLE employees;
```

**The SQL command categories (a common interview question):**
| Category | Stands for | Commands |
|---|---|---|
| **DDL** | Data Definition Language | `CREATE`, `ALTER`, `DROP`, `TRUNCATE` |
| **DML** | Data Manipulation Language | `INSERT`, `UPDATE`, `DELETE` |
| **DQL** | Data Query Language | `SELECT` |
| **DCL** | Data Control Language | `GRANT`, `REVOKE` |
| **TCL** | Transaction Control Language | `COMMIT`, `ROLLBACK`, `SAVEPOINT` |

---

## 6.8 Indexes and Constraints

**Indexes** — a data structure (typically a B+ Tree) that speeds up data retrieval at the cost of slower writes (since the index must also be updated) and extra storage:
```sql
CREATE INDEX idx_department ON employees(department);
DROP INDEX idx_department ON employees;
```
Indexes are most beneficial on columns frequently used in `WHERE`, `JOIN`, or `ORDER BY` clauses, especially on large tables.

**Primary Key constraint** — uniquely identifies each row; cannot be NULL; automatically indexed:
```sql
CREATE TABLE departments (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50)
);
```

**Foreign Key constraint** — enforces referential integrity by linking a column to a Primary Key in another table:
```sql
CREATE TABLE employees (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100),
    dept_id INT,
    FOREIGN KEY (dept_id) REFERENCES departments(id)
);
```
A foreign key prevents inserting an `employees` row with a `dept_id` that doesn't exist in `departments`, and (depending on `ON DELETE`/`ON UPDATE` rules) controls what happens to related rows if a parent row is deleted (`CASCADE`, `SET NULL`, `RESTRICT`).

**UNIQUE constraint** — ensures all values in a column are distinct (unlike Primary Key, a table can have multiple UNIQUE columns, and UNIQUE columns CAN contain one NULL):
```sql
CREATE TABLE employees (
    id INT PRIMARY KEY,
    email VARCHAR(100) UNIQUE
);
```

**CHECK constraint** — enforces a condition that all values in a column must satisfy:
```sql
CREATE TABLE employees (
    id INT PRIMARY KEY,
    age INT CHECK (age >= 18),
    salary DECIMAL(10,2) CHECK (salary > 0)
);
```

**NOT NULL constraint** — ensures a column cannot store NULL values:
```sql
name VARCHAR(100) NOT NULL
```


---
---

# MODULE 3: C# AND ADO.NET

## 7.1 Introduction to C# and .NET 8

**The .NET ecosystem:** .NET is a free, open-source, cross-platform development platform created by Microsoft for building many types of applications (web, desktop, mobile, cloud, games) using languages like C#, F#, and VB.NET.

**Key .NET versions:**
- **.NET Framework** — original, Windows-only version (legacy)
- **.NET Core** — cross-platform rewrite (versions 1–3.1)
- **.NET 5+** — unified platform, dropping the "Core" name (.NET 5, 6, 7, 8...) — this is the current, actively developed line. **.NET 8** is a Long-Term Support (LTS) release.

**C# 12 highlights (paired with .NET 8):**
- Primary constructors for all classes/structs (previously only for `record` types)
- Collection expressions (`[1, 2, 3]` shorthand)
- Default lambda parameters
- `ref readonly` parameters

**Setting up the environment:**
- Install the **.NET SDK** (Software Development Kit) — includes the compiler, runtime, and CLI tools
- IDE options: **Visual Studio** (full-featured, Windows-focused) or **VS Code** with the C# extension (lightweight, cross-platform)
- Verify installation: `dotnet --version`

```bash
dotnet new console -n MyApp     # create a new console app
cd MyApp
dotnet run                       # compile and run
```

---

## 7.2 C# Syntax and Basic Constructs

**Hello World:**
```csharp
Console.WriteLine("Hello, World!");
```
(C# 9+ supports "top-level statements" — no need for an explicit `Main` method or class wrapper in simple programs; the compiler generates it implicitly.)

Traditional form:
```csharp
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello, World!");
    }
}
```

**Variables, Constants, Data Types:**
```csharp
int age = 21;
double price = 19.99;
float rate = 4.5f;
char grade = 'A';
string name = "Vedasri";
bool isActive = true;
const double Pi = 3.14159;     // constant — cannot be reassigned, must be set at declaration
```

**Common C# data types:**
| Type | Size | Range/Notes |
|---|---|---|
| `int` | 4 bytes | Whole numbers |
| `long` | 8 bytes | Larger whole numbers |
| `float` | 4 bytes | Single-precision decimal (suffix `f`) |
| `double` | 8 bytes | Double-precision decimal (default for decimals) |
| `decimal` | 16 bytes | High precision, used for currency/financial calculations |
| `char` | 2 bytes | Single Unicode character |
| `bool` | 1 byte | `true`/`false` |
| `string` | reference type | Sequence of characters |

**Value vs Reference Types (a key C# interview topic):**
- **Value types** (`int`, `double`, `bool`, `struct`, `enum`) — stored directly on the **stack**; assigning copies the actual value.
- **Reference types** (`class`, `string`, `array`, `object`) — the variable stores a reference (pointer) to data on the **heap**; assigning copies the reference, not the underlying data.

```csharp
int a = 5;
int b = a;     // b gets a COPY of 5
b = 10;        // a is still 5

int[] arr1 = {1, 2, 3};
int[] arr2 = arr1;    // arr2 references the SAME array object
arr2[0] = 99;
// arr1[0] is now also 99 — they point to the same memory
```

**Type Inference with `var` and `new()`:**
```csharp
var name = "Vedasri";          // compiler infers 'string' at compile time (still strongly typed!)
var numbers = new List<int>(); // inferred as List<int>

List<int> scores = new();      // target-typed new() (C# 9+) — type is inferred from the left side
```
`var` is NOT the same as JavaScript's dynamic typing — the type is fixed at compile time, just inferred rather than explicitly written.

---

## 7.3 Control Flow Statements

**Conditional statements:**
```csharp
if (age >= 18) {
    Console.WriteLine("Adult");
} else if (age >= 13) {
    Console.WriteLine("Teen");
} else {
    Console.WriteLine("Child");
}

switch (day) {
    case "Mon":
        Console.WriteLine("Start");
        break;
    case "Fri":
    case "Sat":           // multiple case fall-through is allowed when grouped like this
        Console.WriteLine("Weekend-ish");
        break;
    default:
        Console.WriteLine("Midweek");
        break;
}
```

**C# 12 switch expression (more concise than traditional switch statement):**
```csharp
string category = age switch {
    < 13 => "Child",
    < 20 => "Teen",
    _ => "Adult"          // '_' is the discard pattern, acts as default
};
```

**Iterative statements:**
```csharp
for (int i = 0; i < 5; i++) { Console.WriteLine(i); }

int j = 0;
while (j < 5) { Console.WriteLine(j); j++; }

int k = 0;
do { Console.WriteLine(k); k++; } while (k < 5);   // runs at least once

foreach (int num in new[] {1, 2, 3}) {
    Console.WriteLine(num);
}
```

**Pattern Matching (switch expressions, `is` patterns):**
```csharp
object obj = 42;
if (obj is int n && n > 10) {
    Console.WriteLine($"It's an int greater than 10: {n}");
}

string Describe(object shape) => shape switch {
    Circle c => $"Circle with radius {c.Radius}",
    Square s => $"Square with side {s.Side}",
    null => "No shape",
    _ => "Unknown shape"
};
```

---

## 7.4 Functions and Methods

**Defining and Calling Methods:**
```csharp
int Add(int a, int b) {
    return a + b;
}
int result = Add(3, 5);
```

**Parameter modifiers — `in`, `out`, `ref`:**
```csharp
// ref — passes by reference; must be initialized BEFORE calling
void Double(ref int x) { x *= 2; }
int num = 5;
Double(ref num);   // num is now 10

// out — passes by reference; does NOT need to be initialized before the call (must be assigned inside the method)
bool TryParse(string input, out int result) {
    return int.TryParse(input, out result);
}
int.TryParse("42", out int value);  // value = 42

// in — passes by reference but READ-ONLY inside the method (prevents accidental modification, avoids copy overhead for large structs)
void Display(in int x) { Console.WriteLine(x); }
```

| Modifier | Must be initialized before call? | Can be modified inside method? | Direction |
|---|---|---|---|
| (none, by value) | Yes | N/A (copy only) | In only |
| `ref` | Yes | Yes | In and Out |
| `out` | No | Must be assigned | Out only |
| `in` | Yes | No (read-only) | In only (by reference, for performance) |

**Default values:**
```csharp
void Greet(string name = "Guest") {
    Console.WriteLine($"Hello, {name}");
}
Greet();          // "Hello, Guest"
Greet("Vedasri"); // "Hello, Vedasri"
```

**Method Overloading** — multiple methods with the same name but different parameter signatures, resolved at compile time:
```csharp
int Add(int a, int b) => a + b;
double Add(double a, double b) => a + b;
int Add(int a, int b, int c) => a + b + c;
```

**Local Functions** — a function defined inside another function, useful for helper logic that's only relevant within that scope:
```csharp
int CalculateTotal(int[] prices) {
    int ApplyTax(int price) => price + (price / 10);  // local function
    
    int total = 0;
    foreach (var p in prices) total += ApplyTax(p);
    return total;
}
```

---

## 7.5 Introduction to OOP Concepts

**Classes and Objects:**
```csharp
class Car {
    public string Model;
    public int Year;
    
    public void Drive() {
        Console.WriteLine($"{Model} is driving.");
    }
}

Car myCar = new Car();   // 'myCar' is an object/instance of class Car
myCar.Model = "Tesla";
myCar.Drive();
```
A **class** is a blueprint; an **object** is a concrete instance created from that blueprint, with its own copy of the instance fields/properties.

**Constructors:**
```csharp
class Car {
    public string Model;
    public Car(string model) {       // constructor — runs automatically when 'new Car(...)' is called
        Model = model;
    }
}
Car c = new Car("Tesla");
```

**Primary Constructors (C# 12 — extended to all classes, not just records):**
```csharp
class Car(string model, int year) {
    public string Model { get; } = model;
    public int Year { get; } = year;
}
```
This drastically reduces boilerplate compared to manually writing a constructor body that assigns each parameter to a field.

**Access Modifiers:**
| Modifier | Accessible from |
|---|---|
| `public` | Anywhere |
| `private` | Only within the same class |
| `protected` | Same class + derived (child) classes |
| `internal` | Anywhere within the same assembly (project) |
| `protected internal` | Same assembly OR derived classes (even in other assemblies) |
| `private protected` | Derived classes, but only within the same assembly |

---

## 7.6 Encapsulation and Properties

**Encapsulation** — bundling data (fields) and the methods that operate on them within a class, while restricting direct external access to internal state, exposed instead through controlled `public` properties/methods.

**Auto-implemented Properties:**
```csharp
class Person {
    public string Name { get; set; }            // auto-implemented — compiler generates a hidden backing field
    public int Age { get; private set; }          // settable only within the class itself
}
```

**Backing Fields (manual property implementation, useful when validation logic is needed):**
```csharp
class Person {
    private int age;                  // the actual backing field
    public int Age {
        get { return age; }
        set {
            if (value < 0) throw new ArgumentException("Age cannot be negative");
            age = value;
        }
    }
}
```

**Init-only Setters (C# 9+):** Allow a property to be set only during object initialization, making the object effectively immutable afterward:
```csharp
class Person {
    public string Name { get; init; }
}
var p = new Person { Name = "Vedasri" };
// p.Name = "New Name";  // ❌ compile error — init-only, cannot change after construction
```

**Records:** A reference type designed for immutable data, with built-in **value equality** (two records with identical property values are considered equal, unlike normal classes which compare by reference):
```csharp
record Point(int X, int Y);

var p1 = new Point(1, 2);
var p2 = new Point(1, 2);
Console.WriteLine(p1 == p2);  // true — VALUE equality (a normal class would print false here)
```

**`with` expressions** — create a modified copy of a record without mutating the original:
```csharp
var p3 = p1 with { X = 99 };  // p3 is {X: 99, Y: 2}; p1 is unchanged
```

---

## 7.7 Inheritance and Polymorphism

**Inheritance** — a class (derived/child) can inherit fields/methods from another class (base/parent), promoting code reuse:
```csharp
class Animal {
    public string Name;
    public virtual void Speak() {        // 'virtual' allows this method to be overridden
        Console.WriteLine($"{Name} makes a sound.");
    }
}

class Dog : Animal {
    public override void Speak() {       // 'override' provides a new implementation
        Console.WriteLine($"{Name} barks.");
    }
}
```

**`base` keyword** — calls the parent class's constructor or method from within the derived class:
```csharp
class Dog : Animal {
    public Dog(string name) {
        Name = name;
    }
    public override void Speak() {
        base.Speak();                    // calls Animal's original Speak() first
        Console.WriteLine($"{Name} also barks.");
    }
}
```

**`virtual`/`override` (runtime polymorphism):**
```csharp
Animal a = new Dog { Name = "Rex" };
a.Speak();   // "Rex barks." — even though the variable type is Animal, the ACTUAL object's overridden method runs
```
This is **dynamic dispatch** — the method that executes is determined by the object's actual runtime type, not its declared (compile-time) type.

**Abstract Classes vs Interfaces:**

| | Abstract Class | Interface |
|---|---|---|
| Can have method implementations? | Yes (and abstract/unimplemented methods too) | Default methods allowed since C# 8, but primarily contracts |
| Can have fields? | Yes | No (only properties, methods, events) |
| Multiple inheritance | A class can inherit only ONE abstract class | A class can implement MULTIPLE interfaces |
| Constructors | Yes | No |
| Use case | Shared base behavior + some required customization | A pure contract/capability (e.g., `IComparable`, `IDisposable`) |

```csharp
abstract class Shape {
    public abstract double Area();         // must be implemented by derived classes
    public void Describe() {               // shared, concrete implementation
        Console.WriteLine($"Area is {Area()}");
    }
}

class Circle : Shape {
    public double Radius;
    public override double Area() => Math.PI * Radius * Radius;
}

interface IDrawable {
    void Draw();
}
class Circle2 : Shape, IDrawable {     // a class can extend ONE abstract class AND implement MULTIPLE interfaces
    public void Draw() => Console.WriteLine("Drawing circle");
}
```

---

## 7.8 Records and Structs

(Records covered in 7.6.) 

**Structs** — value types (unlike classes, which are reference types). Good for small, simple data structures where copy-by-value semantics and avoiding heap allocation matter for performance (e.g., `Point`, `Vector2`).

```csharp
struct Point {
    public int X, Y;
    public Point(int x, int y) { X = x; Y = y; }
}

Point p1 = new Point(1, 2);
Point p2 = p1;       // COPIES the entire struct (value type)
p2.X = 99;
// p1.X is still 1 — p1 and p2 are independent copies
```

**Struct improvements in C# 12:** Primary constructors now also apply to `struct`, reducing boilerplate similarly to classes:
```csharp
struct Point(int x, int y) {
    public int X { get; } = x;
    public int Y { get; } = y;
}
```

**Value Equality and Immutability:** Records and structs both support comparing objects by their VALUES rather than by reference identity (unlike ordinary classes). Records are reference types with value equality semantics built in; structs are value types by nature, so they're naturally compared by value.

---

## 7.9 Exception Handling

**try-catch-finally:**
```csharp
try {
    int result = 10 / int.Parse("0");
} catch (DivideByZeroException ex) {
    Console.WriteLine("Cannot divide by zero: " + ex.Message);
} catch (FormatException ex) {
    Console.WriteLine("Invalid number format: " + ex.Message);
} catch (Exception ex) {            // generic catch-all, should come LAST
    Console.WriteLine("Unexpected error: " + ex.Message);
} finally {
    Console.WriteLine("This always runs, regardless of an exception.");
}
```
Catch blocks are evaluated top to bottom — more specific exception types must be caught BEFORE more general ones (`Exception`), or the compiler will flag unreachable code.

**Custom Exceptions:**
```csharp
class InsufficientFundsException : Exception {
    public InsufficientFundsException(string message) : base(message) { }
}

void Withdraw(double amount, double balance) {
    if (amount > balance)
        throw new InsufficientFundsException("Insufficient funds for this withdrawal.");
}
```

**Exception Filters (the `when` clause)** — allows conditional catching, only catching an exception if a specified condition is also true:
```csharp
try {
    // some operation
} catch (Exception ex) when (ex.Message.Contains("timeout")) {
    Console.WriteLine("Handled a timeout-specific error.");
} catch (Exception ex) {
    Console.WriteLine("Handled a different error: " + ex.Message);
}
```

---

## 7.10 Nullable Types and Null Safety

**Handling null references — the `?` operator (nullable value types):**
```csharp
int? age = null;          // 'int?' allows int to also hold null (normal int cannot)
if (age.HasValue) {
    Console.WriteLine(age.Value);
}
```

**Null-conditional operator (`?.`)** — safely accesses a member only if the object isn't null, short-circuiting to `null` instead of throwing `NullReferenceException`:
```csharp
string name = person?.Name;            // if person is null, name becomes null instead of crashing
int? length = person?.Name?.Length;     // chains safely through multiple levels
```

**Null-coalescing operator (`??`)** — provides a fallback value if the left-hand expression is null:
```csharp
string displayName = person?.Name ?? "Unknown";
```

**Null-coalescing assignment (`??=`)** — assigns only if the variable is currently null:
```csharp
name ??= "Default Name";
```

**`required` modifier (C# 11+):** Forces a property to be explicitly set during object initialization, catching missing-required-field bugs at COMPILE time instead of leaving them as silent nulls at runtime:
```csharp
class Person {
    public required string Name { get; set; }
}
var p = new Person { Name = "Vedasri" };  // OK
// var p2 = new Person();   // ❌ compile error — Name is required
```

---

## 7.11 Collections and LINQ

**Core collections:**
```csharp
List<int> numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
numbers.Remove(2);

Dictionary<string, int> ages = new Dictionary<string, int> {
    { "Vedasri", 21 }, { "Rahul", 22 }
};
ages["Vedasri"];                 // 21
ages.TryGetValue("X", out int val);  // safe lookup, avoids exceptions for missing keys

Queue<string> queue = new Queue<string>();
queue.Enqueue("A"); queue.Dequeue();   // FIFO

Stack<string> stack = new Stack<string>();
stack.Push("A"); stack.Pop();           // LIFO
```

**Iterating with `foreach`:**
```csharp
foreach (var num in numbers) {
    Console.WriteLine(num);
}
foreach (var kvp in ages) {
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
```

**LINQ (Language Integrated Query)** — lets you write SQL-like queries directly against collections, in either query syntax or method syntax:
```csharp
List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

// Method syntax (most commonly used)
var evens = nums.Where(n => n % 2 == 0).ToList();      // [2, 4, 6]
var doubled = nums.Select(n => n * 2).ToList();         // [2, 4, 6, 8, 10, 12]
var sum = nums.Sum();
var max = nums.Max();
var sorted = nums.OrderByDescending(n => n).ToList();
var first = nums.FirstOrDefault(n => n > 4);              // 5

// Query syntax (SQL-like, less common in modern code but functionally equivalent)
var evens2 = from n in nums
             where n % 2 == 0
             select n;
```
LINQ uses **deferred execution** — a query isn't actually run until you iterate over it (e.g., via `foreach` or `.ToList()`), which can be a subtle source of bugs if the underlying collection changes between query definition and execution.

---

## 7.12 Tuples and Pattern Matching Enhancements

**Creating and Deconstructing Tuples:**
```csharp
(string name, int age) person = ("Vedasri", 21);
Console.WriteLine(person.name);

// Deconstruction
var (name, age) = person;
Console.WriteLine(name);

// Returning a tuple from a method
(int min, int max) FindMinMax(int[] arr) {
    return (arr.Min(), arr.Max());
}
var (lo, hi) = FindMinMax(new[] {3, 1, 4, 1, 5});
```

**Pattern Matching with `is`:**
```csharp
object value = 5;
if (value is int number && number > 0) {
    Console.WriteLine($"Positive integer: {number}");
}
```

**List Patterns (C# 11/12):** Match against the shape/contents of an array or list directly:
```csharp
int[] numbers = { 1, 2, 3 };
if (numbers is [1, 2, 3]) {
    Console.WriteLine("Exact match!");
}
if (numbers is [var first, .., var last]) {   // '..' is a slice pattern, matches "everything in between"
    Console.WriteLine($"First: {first}, Last: {last}");
}
```

---

## 7.13 Asynchronous Programming with Async/Await

**Tasks and async/await:**
```csharp
async Task<string> FetchDataAsync() {
    await Task.Delay(1000);   // simulates a non-blocking 1-second wait (e.g., a network call)
    return "Data loaded";
}

async Task Main() {
    string result = await FetchDataAsync();
    Console.WriteLine(result);
}
```
`async`/`await` allows long-running operations (file I/O, network calls, database queries) to run without blocking the calling thread, improving responsiveness (especially critical in UI applications and scalable web servers).

**Exception Handling in Async Code:**
```csharp
async Task RunAsync() {
    try {
        await FetchDataAsync();
    } catch (Exception ex) {
        Console.WriteLine("Error: " + ex.Message);
    }
}
```
Exceptions thrown inside an `async` method are captured and re-thrown when the `Task` is awaited — a standard `try-catch` around the `await` call handles them normally.

**`ValueTask` vs `Task` (.NET 8 performance consideration):**
- `Task<T>` is a reference type — always heap-allocated, even for results that complete synchronously/instantly.
- `ValueTask<T>` is a value type/struct — can avoid heap allocation in hot paths where the result is frequently already available synchronously (e.g., cached values), improving performance in high-throughput scenarios.
- Use `Task` by default; reach for `ValueTask` only in performance-critical, frequently-synchronous-completion code paths, since `ValueTask` has more restrictive usage rules (e.g., shouldn't be awaited twice).

---

## 7.14 File Handling and I/O Operations

**Reading and Writing Files:**
```csharp
// Writing
File.WriteAllText("data.txt", "Hello, file!");

// Reading
string content = File.ReadAllText("data.txt");
string[] lines = File.ReadAllLines("data.txt");

// Appending
File.AppendAllText("data.txt", "\nNew line added.");
```

**Working with Streams (`FileStream`, `MemoryStream`):**
```csharp
using (FileStream fs = new FileStream("data.bin", FileMode.Create)) {
    byte[] data = { 1, 2, 3 };
    fs.Write(data, 0, data.Length);
}
```
The `using` statement ensures the stream's `Dispose()` is called automatically once the block exits (even if an exception occurs), releasing the underlying file handle — critical to avoid resource leaks.

`MemoryStream` works like `FileStream` but stores data in memory (RAM) rather than on disk — useful for in-memory processing/transformation of byte data without touching the file system.

**JSON Serialization with `System.Text.Json`:**
```csharp
using System.Text.Json;

class Person { public string Name { get; set; } public int Age { get; set; } }

var person = new Person { Name = "Vedasri", Age = 21 };
string json = JsonSerializer.Serialize(person);     // object → JSON string
Person p2 = JsonSerializer.Deserialize<Person>(json); // JSON string → object
```
`System.Text.Json` is the modern, built-in JSON library in .NET (faster and with no external dependency, replacing the older third-party `Newtonsoft.Json` as the default recommendation in most new projects).

---

## 7.15 Multi-Threading

**What is Multi-Threading?** The ability to run multiple threads (independent sequences of execution) concurrently within a single process, sharing the same memory space.

**Importance:** Improves application responsiveness (e.g., a UI doesn't freeze during a long computation) and can improve throughput by utilizing multiple CPU cores.

**Process vs Thread:** A process has its own isolated memory space; threads within the same process share that memory, making inter-thread communication fast but introducing the risk of concurrency bugs.

**`System.Threading` namespace and `Thread` class:**
```csharp
using System.Threading;

void PrintNumbers() {
    for (int i = 0; i < 5; i++) Console.WriteLine(i);
}

Thread t = new Thread(PrintNumbers);
t.Start();
t.Join();   // waits for the thread to finish before continuing
```

**Thread Life Cycle:** `Unstarted` → `Running` → (`WaitSleepJoin` if blocked) → `Stopped`.

**Obtaining current thread info:**
```csharp
Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
```

**Background Threads:** A thread set with `IsBackground = true` doesn't keep the application alive on its own — when all foreground threads finish, the process exits even if background threads are still running (useful for non-critical tasks like logging).

**Concurrency Issues:**

- **Race Condition:** Occurs when two or more threads access/modify shared data simultaneously, and the final outcome depends unpredictably on the timing/order of execution.
```csharp
int counter = 0;
void Increment() { for (int i = 0; i < 100000; i++) counter++; }  // NOT thread-safe — counter++ is not atomic
```

- **Deadlock:** Two or more threads are each waiting on a resource the other holds, and neither can proceed (see earlier OS-related notes for the four Coffman conditions).

**Synchronization mechanisms:**
```csharp
// lock — the simplest synchronization primitive; ensures only one thread executes the block at a time
private static readonly object _lock = new object();
void Increment() {
    lock (_lock) {
        counter++;
    }
}

// Monitor — what 'lock' compiles down to internally; gives more control (TryEnter, Wait, Pulse)
Monitor.Enter(_lock);
try { counter++; }
finally { Monitor.Exit(_lock); }

// Mutex — like lock, but works ACROSS processes, not just threads within one process (heavier weight)
Mutex mutex = new Mutex();
mutex.WaitOne();
try { counter++; }
finally { mutex.ReleaseMutex(); }
```

**`[Synchronization]` Attribute:** A legacy/older approach (from `ContextBoundObject`) for automatically synchronizing access to an object's methods; largely superseded by explicit `lock`/`Monitor` usage in modern code.

**`TaskScheduler` Class:** Controls how queued `Task` objects are scheduled onto threads (e.g., the default thread pool scheduler vs a custom scheduler that marshals work back onto a UI thread). Most application code uses the default scheduler implicitly via `Task.Run()` and rarely needs to interact with `TaskScheduler` directly.

---

## 7.16 Debugging and Tracing

**Debugging:** The process of identifying and fixing defects in code, typically using an IDE's breakpoints, step-through execution, and variable watch windows.

**Why debug?** Bugs are inevitable in non-trivial software; systematic debugging (rather than guesswork/print-statement-only debugging) saves significant development time.

**Tracing:** Logging diagnostic information about a running application's execution flow — particularly valuable in production environments where attaching a live debugger isn't feasible.

**Debug/Trace Class Members:**
```csharp
using System.Diagnostics;

Debug.WriteLine("This only appears in DEBUG builds");   // stripped out of Release builds
Trace.WriteLine("This appears in both DEBUG and RELEASE builds");
Debug.Assert(x > 0, "x should be positive");              // throws/breaks if condition is false (DEBUG only)
```

**Configuration file `EXE.CONFIG`:** An XML configuration file (legacy .NET Framework concept) used to configure trace listeners, connection strings, and app settings without recompiling the application. (.NET Core/.NET 5+ generally uses `appsettings.json` instead.)

**Conditional Debug Attributes:**
```csharp
[Conditional("DEBUG")]
void LogDebugInfo(string message) {
    Console.WriteLine(message);
}
```
Calls to a method marked `[Conditional("DEBUG")]` are entirely removed by the compiler in non-DEBUG builds — useful for diagnostic code with zero production overhead.

**Logging with `log4net`:** A popular third-party logging framework providing configurable log levels (`DEBUG`, `INFO`, `WARN`, `ERROR`, `FATAL`) and multiple output targets ("appenders" — console, file, database, email):
```csharp
private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
log.Info("Application started");
log.Error("Something failed", exception);
```

---

## 7.17 Secure Coding

**What is Secure Code?** Code written with defensive practices that minimize vulnerabilities exploitable by attackers — security should be designed in from the start, not bolted on afterward.

**SQL Injection:** Occurs when untrusted user input is concatenated directly into a SQL query string, allowing an attacker to inject malicious SQL:
```csharp
// ❌ VULNERABLE
string query = "SELECT * FROM Users WHERE username = '" + userInput + "'";
// If userInput = "' OR '1'='1", the query becomes a tautology, returning ALL rows

// ✅ SAFE — parameterized query
SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE username = @username", conn);
cmd.Parameters.AddWithValue("@username", userInput);
```

**Cross-Site Scripting (XSS):** Occurs when untrusted user input is rendered as raw HTML/JS in a web page, allowing an attacker to inject malicious scripts that execute in other users' browsers. Mitigation: always HTML-encode user-supplied output before rendering it (most modern frameworks like Razor/ASP.NET do this by default).

**XML Vulnerabilities:** XML parsers that resolve external entities (XXE — XML External Entity attacks) can be tricked into reading local files or making network requests. Mitigation: disable DTD processing/external entity resolution in the XML parser configuration.

**Basics of Web Security — Authentication vs Authorization:**
- **Authentication:** Verifying WHO a user is (e.g., login with username/password, validating a JWT token).
- **Authorization:** Verifying WHAT an authenticated user is allowed to do (e.g., role-based access control).

```csharp
// ASP.NET example
[Authorize(Roles = "Admin")]
public IActionResult AdminPanel() { ... }
```

**Broken Authentication and Session Management:** Vulnerabilities arising from weak password policies, predictable session IDs, missing session timeouts, or session tokens exposed in URLs. Mitigation: use framework-provided authentication (ASP.NET Identity), enforce HTTPS, set secure/HttpOnly cookie flags, implement reasonable session expiration.

**Security Misconfiguration:** Leaving default credentials active, verbose error messages exposing stack traces/internal details in production, or unnecessary services/ports left open. Mitigation: harden configurations, disable detailed error pages in production (`app.UseExceptionHandler` instead of `UseDeveloperExceptionPage` in ASP.NET).

**Cross-Site Request Forgery (CSRF):** Tricks an authenticated user's browser into unknowingly submitting a malicious request to a site they're logged into (e.g., an attacker-crafted form auto-submitting to a banking site). Mitigation: anti-forgery tokens (ASP.NET's `[ValidateAntiForgeryToken]`), checking the `Origin`/`Referer` header, using `SameSite` cookie attributes.

---

## 7.18 ADO.NET Fundamentals

**What is ADO.NET?** ActiveX Data Objects .NET — a set of .NET classes for connecting to and interacting with data sources (primarily relational databases) from C# code.

**Why we need ADO.NET:** Provides a consistent, provider-agnostic way to execute SQL commands, retrieve results, and manage database connections from .NET applications, abstracting away the low-level details of each specific database driver.

**Connection Architectures — Connected vs Disconnected:**

| | Connected Architecture | Disconnected Architecture |
|---|---|---|
| Connection state | Stays open while reading data | Opens briefly, fetches data, then closes |
| Classes used | `Connection`, `Command`, `DataReader` | `Connection`, `DataAdapter`, `DataSet`/`DataTable` |
| Data access | Forward-only, read-only, streamed row-by-row | Entire result set held in memory, can be edited offline |
| Performance | Fast for simple sequential reads | Better for working with data across multiple operations without holding a connection open |
| Scalability | Holds a connection open longer — can strain connection pools under load | More scalable for many concurrent users since connections are released quickly |

**ADO.NET Class Library:**

| Class | Role |
|---|---|
| `SqlConnection` | Opens/manages a connection to the database |
| `SqlCommand` | Represents a SQL statement (query or stored procedure) to execute |
| `SqlDataReader` | Provides fast, forward-only, read-only access to query results (connected architecture) |
| `SqlDataAdapter` | Bridges between a `DataSet`/`DataTable` and the database; fills and updates data (disconnected architecture) |
| `DataSet` | An in-memory collection of one or more `DataTable` objects, representing a disconnected cache of data |
| `DataTable` | An in-memory representation of a single table's rows/columns |

**Connecting to a database:**
```csharp
using System.Data.SqlClient;   // or Microsoft.Data.SqlClient (recommended modern package)

string connStr = "Server=localhost;Database=TestDB;User Id=sa;Password=pass;";

using (SqlConnection conn = new SqlConnection(connStr)) {
    conn.Open();
    Console.WriteLine("Connected successfully!");
}  // connection automatically closed/disposed when the 'using' block exits
```

**Retrieving data using `SqlDataReader` (Connected architecture):**
```csharp
using (SqlConnection conn = new SqlConnection(connStr)) {
    conn.Open();
    SqlCommand cmd = new SqlCommand("SELECT id, name FROM Employees", conn);
    using (SqlDataReader reader = cmd.ExecuteReader()) {
        while (reader.Read()) {                          // moves forward one row at a time
            Console.WriteLine($"{reader["id"]} - {reader["name"]}");
        }
    }
}
```

**Modifying data with `SqlCommand` (`INSERT`/`UPDATE`/`DELETE`):**
```csharp
using (SqlConnection conn = new SqlConnection(connStr)) {
    conn.Open();
    SqlCommand cmd = new SqlCommand(
        "INSERT INTO Employees (name, salary) VALUES (@name, @salary)", conn);
    cmd.Parameters.AddWithValue("@name", "Vedasri");
    cmd.Parameters.AddWithValue("@salary", 55000);
    int rowsAffected = cmd.ExecuteNonQuery();    // used for INSERT/UPDATE/DELETE — returns # of rows affected
}
```
`ExecuteReader()` is used for `SELECT` queries that return rows; `ExecuteNonQuery()` is used for `INSERT`/`UPDATE`/`DELETE` (returns affected row count, not data); `ExecuteScalar()` is used when a query returns a single value (e.g., `SELECT COUNT(*) ...`).

Always use **parameterized queries** (`cmd.Parameters.AddWithValue(...)`) instead of string-concatenating user input directly into SQL — this is the primary defense against SQL Injection (see Secure Coding section above).

**Retrieving/modifying data using `DataAdapter` and `DataSet` (Disconnected architecture):**
```csharp
using (SqlConnection conn = new SqlConnection(connStr)) {
    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", conn);
    DataSet ds = new DataSet();
    adapter.Fill(ds, "Employees");          // opens connection, fills DataSet, closes connection automatically

    DataTable table = ds.Tables["Employees"];
    foreach (DataRow row in table.Rows) {
        Console.WriteLine($"{row["id"]} - {row["name"]}");
    }

    // Modify data in memory, then push changes back
    table.Rows[0]["name"] = "Updated Name";
    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);  // auto-generates UPDATE/INSERT/DELETE commands
    adapter.Update(ds, "Employees");          // re-opens connection briefly to persist changes
}
```
The disconnected model (`DataAdapter`/`DataSet`) is well-suited to scenarios like binding data to desktop UI grids, where the user may browse/edit data over an extended period without needing (or wanting) to hold a live database connection open the entire time.

---
---

# Quick-Reference Summary Table

| Module | Topic | Core Skill Demonstrated |
|---|---|---|
| 1 | HTML5 | Semantic structure, forms, storage, geolocation |
| 1 | CSS3 | Styling, box model, responsive design |
| 1 | JavaScript | Logic, DOM manipulation, async programming, ES6+ |
| 1 | Bootstrap 5 | Rapid responsive UI using a component framework |
| 1 | jQuery | Simplified DOM/event handling (legacy but common) |
| 2 | ANSI SQL/MySQL | Relational data querying, joins, schema design |
| 3 | C# | OOP, modern language features, async, multithreading |
| 3 | ADO.NET | Connecting C# applications to relational databases |

---

*Notes compiled for personal study/preparation based on the Cognizant Digital Nurture 5.0 — DotNet FSE Upskilling Handbook (© 2026-2027 Cognizant | Private). All code examples are original and written for learning purposes.*
