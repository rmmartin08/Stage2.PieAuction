# Front-End Concepts and Tools

Welcome to the world of Front-End technology!

## References

- [JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference)
- [jQuery](https://api.jquery.com/)
- [Bootstrap](https://getbootstrap.com/docs/4.4/getting-started/introduction/)
- [StackOverflow](https://stackoverflow.com/) -- Not official documentation, this is a place for code-related questions. Your mileage may vary, but many of the users explain things in new and different ways and the accepted answers tend to be high-quality. Copying and pasting code from StackOverflow is frowned-upon unless you know and can explain how the code works.
- Google -- If you preface your search with the proper technology and a reasonably specific query, (Ex: "bootstrap button" or "jquery click"), 99% of the time you'll immediately see specific links to articles in the documentation, questions and answers on StackOverflow, and other blogs and sites that often help to explain concepts and syntax.

## The DOM

Every web page you load has its own environment called the [Document Object Model](https://en.m.wikipedia.org/wiki/Document_Object_Model) or DOM. The DOM represents HTML tags as a nested tree structure. This environment is living, and when you use JavaScript and jQuery, you are making changes to the content within the DOM.

### HTML Element

HTML stands for Hypertext Markup Language. The "Markup" in this acronym indicates that HTML is not a programming language. Instead HTML is parsed by a web browser, and the tags surrounding content (`< ... >`) tell the browser how the content should be displayed.

An HTML Element is a block of code that encapsulates content for the page. The type of HTML tag tells your web browser what kind of content is being rendered. For example, a Paragraph Element (`<p>`) tells the browser to display text content. An Anchor Element (`<a>`) tells the browser to show a link to another page or another site (the `href` property inside the tag tells it where to link to). A Div Element (`<div>`) is a generic container that is used to help you structure content within the DOM. A Button Element (`<button>`) is exactly what it sounds like, and each browser usually has a slightly different way of showing a button.

Example:

```html
<div id="header">
    <p>SuperCool Website</p>
    <div id="menu">
        <a href="/home" class="menu-link">Home</a>
        <a href="/about" class="menu-link">About</a>
    </div>
    <div id="buttons">
        <button>
            Need Help?
        </button>
        <button class="small">
            Donate
        </button>
    </div>
</div>
```

### CSS Styles

CSS stands for Cascading Style Sheets. When the web first came to be, there was only HTML and CSS was later created to make things look pretty. CSS Classes and IDs are used to tell CSS which elements should be styled and in what way. In CSS, classes are denoted with a dot (`.`) and ids are denoted with a pound/hash (`#`). CSS can also target Elements by using the name of the tag (p, a, div, button, etc).

Example:

```css
#header {
    height: 20px;
}

.menu-link {
    color: green;
}

button {
    padding: 10px;
}

.small {
    padding: 5px;
}

```

### JavaScript

JavaScript is a Front-End programming language that was created to add dynamic action to web pages. It operates by making changes to the DOM, and by adding new data or editing existing data. Like HTML and CSS, JavaScript is parsed and executed by the web browser.

In the following example, `document` is a pre-defined variable that points to the top level of our DOM. The function `.getElementById()` is a native method attached to the `document` variable, which searches the DOM for any element with an ID that matches the text and returns that Element.

```
var headerElement = document.getElementById('header');
headerElement.style.color = 'blue';
```

JavaScript operations can be chained--meaning that if a function returns a value, that value can be operated upon by appending a dot and a new function to the end of a statement. The following example has the same result as the example listed above.

```
document.getElementById('header').style.color = 'blue';
```

### DOM Events

The DOM has a native form of dynamic interaction called [Events](https://developer.mozilla.org/en-US/docs/Web/Events), which occur at certain points throughout the life cycle of a web page. These events occur automatically when certain things happen on a page, and they can also be triggered manually using JavaScript. The most useful thing about Events in Front-End development is that JavaScript can also listen for events to happen. Using the [native JavaScript method](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener) `.addEventListener()`, you can attach a function that will be run any time an event occurs. We'll discuss events more later and how to effectively use them.

## Third-Party Libraries

### Bootstrap

(Bootstrap)[https://getbootstrap.com/docs/4.4/getting-started/introduction/] is a third-party library that mainly consists of pre-built CSS classes. These pre-built classes can make front-end development a lot faster because you don't have to bother with the CSS. Instead of defining your own styles, you can simply include a link to the bootstrap library add then a CSS class to your HTML elements to style them.

Example:

```html
<!--Include Bootstrap-->
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

<button class="btn btn-primary">Pretty Button</button>
```

### jQuery

[jQuery](https://api.jquery.com/) is a third-party library which is similar to Bootstrap in a lot of ways. However instead of adding CSS classes for us to use, it provides pre-built JavaScript functionality. Everything that jQuery does could also be done in pure JavaScript, but jQuery makes development faster and easier.

The jQuery library defines a variable called `$` or `jQuery`, which contains all of jQuery's functionality. Any statement that begins with `$( ... )` is using a jQuery function. The primary way of using jQuery across the web is by using "selectors" to find the HTML elements we want to effect and then doing operations upon them. jQuery's Selectors have syntax very similar to CSS, meaning that the following example does exactly the same as the two JavaScript examples above.

```js
$('#header').style.color = "blue";
```

jQuery also has lots of helper functions and another way to write the above example using a jQuery function would be:

```js
$('#header').css({ color: blue; });
```

jQuery Selectors don't always return one element. If we use a jQuery Selector to find all elements with a given class, there will be multiple results in the returned object. The following example will apply a color change to *all* elements that have a class of "menu-link".

```js
$('.menu-link').css({ color: green; });
```

In this code, the `$()` indicates that we are creating a jQuery object. The `'.menu-link'` inside of that function indicates that we are finding all elements that have a class of "menu-link" and the `.css()` indicates that we are then running the [jQuery .css() Method](https://api.jquery.com/css/#css2) on each of those results.


#### Selectors and Syntax

Simple Selectors

`$('#elementId')`   : (#) Selects all elements with the specified ID. (As a rule, all IDs should be unique to one element.)
`$('.elementClass')`: (.) Selects all elements with the specified ID.
`$('tag')`          : (No symbol) Selects all elements of a specified HTML tag. (For example, 'button' would select all button elements.)

Complex Selectors

`$('#elementId.elementClass')`: (# and .) Selects all elements with the specified ID that also have the specified class.
`$('div.elementClass')`       : (tag and .) Selects all `div` elements with the specified class.
`$('div#elementId')`          : (tag and #) Selects all `div` elements with the specified ID.

Descendant Selectors
(Note that these selectors contain spaces. JavaScript doesn't pay a lot of attention to spaces, but [they are important when used in jQuery selectors](https://stackoverflow.com/questions/6865910/what-does-a-space-in-a-jquery-selector-mean).)

`$('div .elementClass')`: (tag and .) Selects all elements that have the specified class and are also children of a `div` element.
`$('.elementClass div')`: (. and tag) Selects all `div` elements that are children of elements with the specified class.

#### jQuery and JavaScript

It's important to note that you can combine jQuery and vanilla JavaScript syntactically because jQuery is built on JavaScript. Native JavaScript functions will work on jQuery objects, as long as you are using the correct type of function with the correct type of object. However, one stumbling block is not matching jQuery functions with jQuery objects. The below examples illustrate the differences.

Valid: (jQuery Object calling jQuery Method)
```js
$('.menu-link').css({ color: green; });
```

Valid: (jQuery Object calling Native JavaScript Method)
```js
$('#menu').getElementsByClassName('menu-link');
```

Invalid: (Native JavaScript Object calling jQuery Method)
```js
document.getElementsByClassName('menu-link').css({ color: green; });
```

Valid: (We can make the above example valid by passing the statement wrapped with jQuery)
```js
$(document.getElementsByClassName('menu-link')).css({ color: green; });
```

And this makes the above example is nearly identical to:
```js
$('.menu-link').css({ color: green; });
```

#### Using jQuery to Create Elements

The code that we are using to create a To-Do list often uses tick marks inside of a jQuery object. These tick marks are similar to quotation marks, and in these examples they contain raw HTML code. Using raw HTML inside of a jQuery Object indicates that the text itself should be parsed as HTML code. If we see raw HTML inside of a jQuery object constructor, that means we're not using a jQuery selector but rather creating a new (unattached) HTML element and selecting that element.

```js
$('#header')                        // Select the element with an ID of "header"
```
```js
$(`<div id="header">Header</div>`)  // Create a new div with an id of "header"
```
When we create this new element, we can then insert it into the DOM structure by calling the [jQuery .appendTo() Method](https://api.jquery.com/appendTo/). The following code would add a new link to the Menu we created above in the HTML example.

```js
var newLink = $(`<a href="/new-page" class="menu-link">New Link</a>`);
var menu    = $('#menu');

newLink.appendTo(menu);
```

We can also shorten the above code using chaining, just like in pure JavaScript.

```js
$(`<a href="/new-page" class="menu-link">New Link</a>`).appendTo( $('#menu') );
```

In the above code, our first jQuery object (`$()`) is creating a new jQuery object using literal HTML inside of tick marks. We then apply the `.appendTo()` Method to that object, which will insert that new object somewhere into the DOM structure. `.appendTo()` needs to have an HTML element to target so that it knows where in the DOM structure to add the object. Note the syntax of the argument we give to `.appendTo()`. If we were to pass a simple text string such as: `.appendTo('#menu')`, this would not find a new jQuery object using that string, it would just stay as a string and throw an error! So instead we create another jQuery object and pass that as the argument. It's functionally the same as the preceding example, except that we don't store the results of the selector `$('#menu')` as a variable. Instead we pass it straight into the function.

> **Sidenote**: Remember that JavaScript doesn't pay much attention to spaces? That's true inside of the `.appendTo()` arguments above. `.appendTo( $('#menu') )` is functionally the same as `.appendTo($('#menu'))`. I added these spaces for clarity and you can do the same if you'd like. The biggest place to pay close attention to spaces is within strings (`''` / `""`) and inside of jQuery selectors (which conveniently are also strings): `$('#menu div')`.

> **Sidenote**: Quotation marks (`''` / `""`) in JavaScript and jQuery are nearly identical. In jQuery, `$('#menu')` is the same as `$("#menu")` and you can use either single or double quotation marks as long as you use the same type to both open and close a string. (Invalid: `$("#menu')` ) There are some [small differences between single and double quotes](https://stackoverflow.com/questions/242813/when-to-use-double-or-single-quotes-in-javascript) when escaping literal characters that you probably won't run into. Back tick marks (``) [are a bit more special](https://stackoverflow.com/questions/27678052/usage-of-the-backtick-character-in-javascript), but it seems that the biggest reason for their use in the example To-Do code is to avoid having to escape either single or double quotes inside of our HTML strings.

#### jQuery Event Listeners

Remember DOM Events? jQuery has some handy shortcuts for managing them. The biggest one you'll see out there is a method called `.click()` which listens for a mouse click on a DOM Element. When that element is clicked, the function is performed. These events can be placed on almost anything.

Here's a reference to part of our HTML structure listed above:

```html
<div id="menu">
    <a href="/home" class="menu-link">Home</a>
    <a href="/about" class="menu-link">About</a>
</div>
```

And here are some JavaScript statements that attach click listeners to elements:

The Element with an ID of 'menu'
```js
$('#menu').click(function() {
    console.log('Clicked #menu');
});
```

Every Element with a class of 'menu-link'
```js
$('.menu-link').click(function() {
    console.log('Clicked .menu-link');
});
```

If we were to run *both* of these statements, there would be a click listener on the `div` element and both interior `a` elements. Because the `a` elements are children of the `div`, a click to one of those would also register as a click to the parent. This means that clicking on the link labeled "Home" would output a console log of:

```
Clicked .menu-link
Clicked #menu
```

There's also a default object that is passed into all `.click()` functions called `event`. You can rename this objectif you'd like by putting a new name into the function's arguments. Lowercase e is a very common example. This event variable stores all information about the event that triggered it. For example:

```js
$('.menu-link').click(function() {
    console.log(event);
});
```

... is the same as ...

```js
$('.menu-link').click(function(e) {
    console.log(e);
});
```

These will result in a console log of:

```
> MouseEvent { ... }
```

In the console, you can expand this event declaration to see a plethora of information describing the event itself. One very useful part of this output is `event.target`, which contains the exact HTML Element that triggered the event. From here you can access various properties of the target element. For instance:

```js
$('.menu-link').click(function() {
    console.log(event.target.parentElement.id);
});
```

With the above snippet, clicking on either of the Menu Links would output ...

```
menu
```

#### Handy jQuery functions

- [.append()](https://api.jquery.com/children/)
- [.find()](https://api.jquery.com/find/)
- [.children()](https://api.jquery.com/children/)
- [.click()](https://api.jquery.com/click/)

Refer to the documentation when you see something you don't recognize and need to understand better!