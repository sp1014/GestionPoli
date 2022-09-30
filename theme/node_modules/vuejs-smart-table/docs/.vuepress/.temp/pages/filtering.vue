<template><h1 id="filtering"><a class="header-anchor" href="#filtering">#</a> Filtering</h1>
<p>Smart Table is not concerned with the UI elements you choose to present the filtering options.
This way you can craft any UI for your users to interact with the filters
and just let Smart Table take care of the actual filtering.</p>
<h2 id="filters"><a class="header-anchor" href="#filters">#</a> Filters <Badge text="BasicFilter | CustomFilter"/></h2>
<p>To enable filtering you need to provide the <code>filters</code> property on the <code>VTable</code> component.</p>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTable</span>
  <span class="token attr-name">:data</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>data<span class="token punctuation">"</span></span>
  <span class="token attr-name">:filters</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters<span class="token punctuation">"</span></span>
<span class="token punctuation">></span></span>
</code></pre><div class="highlight-lines"><br><br><div class="highlight-line">&nbsp;</div><br></div><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br></div></div><p>The <code>filters</code> object needs to be a reactive object where each property represents a filter, for example:</p>
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code><span class="token function-variable function">data</span><span class="token operator">:</span> <span class="token punctuation">(</span><span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token punctuation">(</span><span class="token punctuation">{</span>
  filters<span class="token operator">:</span> <span class="token punctuation">{</span>
    name<span class="token operator">:</span> <span class="token punctuation">{</span> value<span class="token operator">:</span> <span class="token string">''</span><span class="token punctuation">,</span> keys<span class="token operator">:</span> <span class="token punctuation">[</span><span class="token string">'name'</span><span class="token punctuation">]</span> <span class="token punctuation">}</span>
  <span class="token punctuation">}</span>
<span class="token punctuation">}</span><span class="token punctuation">)</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br></div></div><p>The entry Key is just for you, so you can reference any of the filters by its name.
The entry value is what Smart Table will use to perform the actual filtering.</p>
<p>There two types of filters <code>BasicFilters</code> and <code>CustomFilters</code></p>
<h2 id="basic-filters"><a class="header-anchor" href="#basic-filters">#</a> Basic Filters <Badge text="BasicFilter"/></h2>
<p>Basic filters are very straight forward. These are the kind you will use the most.</p>
<p>The typescript definition for a Basic Filter is:</p>
<div class="language-typescript ext-ts line-numbers-mode"><pre v-pre class="language-typescript"><code><span class="token keyword">interface</span> <span class="token class-name">BasicFilter</span> <span class="token punctuation">{</span>
  value<span class="token operator">:</span> <span class="token builtin">string</span>
  keys<span class="token operator">:</span> <span class="token builtin">string</span><span class="token punctuation">[</span><span class="token punctuation">]</span>
  exact<span class="token operator">?</span><span class="token operator">:</span> <span class="token builtin">boolean</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br></div></div><h3 id="value"><a class="header-anchor" href="#value">#</a> value <Badge text="string" type="tip"/></h3>
<p>This is the filter string, this is the string we will match against.</p>
<p>You would normally bind it to the <code>v-model</code> of an input element. As you type,
the rows will be filtered. Keep in mind that an empty <code>value</code> means there is no filter.</p>
<h3 id="keys"><a class="header-anchor" href="#keys">#</a> keys <Badge text="string[]" type="tip"/></h3>
<p>This is an Array of Strings indicating what fields of each row the filter <code>value</code> will apply to.</p>
<p>You must provide at least one key. If more than one key is provided as long as one of the row fields matches the filter,
the row will be displayed.</p>
<h3 id="exact"><a class="header-anchor" href="#exact">#</a> exact <Badge text="boolean" type="tip"/> <Badge text="optional" type="tip"/></h3>
<p>By default, a row will be displayed if the filter <code>value</code> is contained on any of the specified <code>keys</code>.
On top of that by default the string are converted to lowercase before compared.</p>
<p>However, sometimes you do want it to be an exact match,
for those cases set <code>exact</code> to <code>true</code> and the comparison will be performed with <code>===</code>.</p>
<h4 id="example"><a class="header-anchor" href="#example">#</a> Example</h4>
<CodeGroup>
  <CodeGroupItem title="html" active>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span><span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>label</span><span class="token punctuation">></span></span>Filter by Name:<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>label</span><span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>input</span> <span class="token attr-name">v-model</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters.name.value<span class="token punctuation">"</span></span><span class="token punctuation">/></span></span>

  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTable</span>
    <span class="token attr-name">:data</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>users<span class="token punctuation">"</span></span>
    <span class="token attr-name">:filters</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters<span class="token punctuation">"</span></span>
  <span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Name<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Age<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Email<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Address<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#body</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>{ rows }<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>tr</span> <span class="token attr-name">v-for</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>row in rows<span class="token punctuation">"</span></span> <span class="token attr-name">:key</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>row.guid<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.name }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.age }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.email }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>
          {{ row.address.street }}, 
          {{ row.address.city }} 
          {{ row.address.state }}
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>tr</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTable</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
</code></pre><div class="highlight-lines"><br><br><br><br><br><br><div class="highlight-line">&nbsp;</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br></div><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br><span class="line-number">12</span><br><span class="line-number">13</span><br><span class="line-number">14</span><br><span class="line-number">15</span><br><span class="line-number">16</span><br><span class="line-number">17</span><br><span class="line-number">18</span><br><span class="line-number">19</span><br><span class="line-number">20</span><br><span class="line-number">21</span><br><span class="line-number">22</span><br><span class="line-number">23</span><br><span class="line-number">24</span><br><span class="line-number">25</span><br><span class="line-number">26</span><br><span class="line-number">27</span><br><span class="line-number">28</span><br></div></div>  </CodeGroupItem>
  <CodeGroupItem title="js">
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code><span class="token keyword">import</span> users <span class="token keyword">from</span> <span class="token string">'./users.json'</span>

<span class="token keyword">export</span> <span class="token keyword">default</span> <span class="token punctuation">{</span>
    name<span class="token operator">:</span> <span class="token string">'BasicFiltering'</span><span class="token punctuation">,</span>
    <span class="token function-variable function">data</span><span class="token operator">:</span> <span class="token punctuation">(</span><span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token punctuation">(</span><span class="token punctuation">{</span>
        users<span class="token punctuation">,</span>
        filters<span class="token operator">:</span> <span class="token punctuation">{</span>
          name<span class="token operator">:</span> <span class="token punctuation">{</span> value<span class="token operator">:</span> <span class="token string">''</span><span class="token punctuation">,</span> keys<span class="token operator">:</span> <span class="token punctuation">[</span><span class="token string">'name'</span><span class="token punctuation">]</span> <span class="token punctuation">}</span>
        <span class="token punctuation">}</span>
    <span class="token punctuation">}</span><span class="token punctuation">)</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br></div></div>  </CodeGroupItem>
</CodeGroup>
<h4 id="result"><a class="header-anchor" href="#result">#</a> Result</h4>
<BasicFiltering/>
<h2 id="custom-filters"><a class="header-anchor" href="#custom-filters">#</a> Custom Filters <Badge text="CustomFilter"/></h2>
<p>You also have the option to provide a custom filter for more complex situations.
A Custom Filter is a function with two arguments: The filter <code>value</code> and the current <code>row</code>.
It should return <code>true</code> if the row should be displayed and <code>false</code> otherwise.</p>
<p>Unlike Basic Filters where the filter <code>value</code> must be a <code>string</code> with Custom Filters the filter <code>value</code> can be anything,
you are in control of it.</p>
<p>The typescript definition for custom filter is:</p>
<div class="language-typescript ext-ts line-numbers-mode"><pre v-pre class="language-typescript"><code><span class="token keyword">interface</span> <span class="token class-name">CustomFilter</span> <span class="token punctuation">{</span>
  value<span class="token operator">?</span><span class="token operator">:</span> <span class="token builtin">unknown</span><span class="token punctuation">;</span>
  <span class="token function-variable function">custom</span><span class="token operator">:</span> <span class="token punctuation">(</span>value<span class="token operator">:</span> <span class="token builtin">any</span><span class="token punctuation">,</span> row<span class="token operator">:</span> Record<span class="token operator">&lt;</span><span class="token builtin">string</span><span class="token punctuation">,</span> <span class="token builtin">any</span><span class="token operator">></span><span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token builtin">boolean</span><span class="token punctuation">;</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br></div></div><h3 id="value-1"><a class="header-anchor" href="#value-1">#</a> value <Badge text="Any" type="success"/></h3>
<p>The same as with Basic Filters, the <code>value</code> is what you will use to match against, but unlike Basic Filters this <code>value</code> is not limited to
<code>strings</code>, it can be anything. This <code>value</code> will be the first argument of your custom function.</p>
<p>Again, just as with Basic Filters, the <code>value</code> is what your will bind to a <code>v-model</code> but now you are not limited to just text inputs.</p>
<h3 id="custom"><a class="header-anchor" href="#custom">#</a> custom <Badge text="CustomFilterFunction" type="info"/></h3>
<p>This is the custom filtering function. Its typescript definition is:</p>
<div class="language-typescript ext-ts line-numbers-mode"><pre v-pre class="language-typescript"><code><span class="token keyword">type</span> <span class="token class-name">CustomFilterFunction</span> <span class="token operator">=</span>
  <span class="token punctuation">(</span>value<span class="token operator">:</span> <span class="token builtin">any</span><span class="token punctuation">,</span> row<span class="token operator">:</span> Record<span class="token operator">&lt;</span><span class="token builtin">string</span><span class="token punctuation">,</span> <span class="token builtin">any</span><span class="token operator">></span><span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token builtin">boolean</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br></div></div><p>The <code>value</code> parameter is the filter value, you will compare it to your rows. This <code>value</code> is the same <code>value</code> we specified above.</p>
<p>The <code>row</code> parameter represent a row in your table, you will compare your <code>value</code> against this <code>row</code>.</p>
<p>The function must return a <code>boolean</code>. If <code>true</code> it means the row should be displayed, if <code>false</code> the row will not be displayed.</p>
<h4 id="example-1"><a class="header-anchor" href="#example-1">#</a> Example</h4>
<CodeGroup>
  <CodeGroupItem title="html" active>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>label</span> <span class="token attr-name">class</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>form-label<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Min Age:<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>label</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>input</span>
  <span class="token attr-name">class</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>form-input<span class="token punctuation">"</span></span>
  <span class="token attr-name">type</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>number<span class="token punctuation">"</span></span>
  <span class="token attr-name">v-model.number</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters.age.value.min<span class="token punctuation">"</span></span>
  <span class="token attr-name">:min</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>0<span class="token punctuation">"</span></span>
  <span class="token attr-name">:max</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters.age.value.max<span class="token punctuation">"</span></span>
  <span class="token attr-name">@onKeyDown.prevent</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>() => {}<span class="token punctuation">"</span></span>
<span class="token punctuation">/></span></span>

<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>label</span> <span class="token attr-name">class</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>form-label<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Max Age:<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>label</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>input</span>
  <span class="token attr-name">class</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>form-input<span class="token punctuation">"</span></span>
  <span class="token attr-name">type</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>number<span class="token punctuation">"</span></span>
  <span class="token attr-name">v-model.number</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters.age.value.max<span class="token punctuation">"</span></span>
  <span class="token attr-name">:min</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters.age.value.min<span class="token punctuation">"</span></span>
  <span class="token attr-name">:max</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>99<span class="token punctuation">"</span></span>
  <span class="token attr-name">@onKeyDown.prevent</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>() => {}<span class="token punctuation">"</span></span>
<span class="token punctuation">/></span></span>

<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTable</span>
  <span class="token attr-name">:data</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>users<span class="token punctuation">"</span></span>
  <span class="token attr-name">:filters</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>filters<span class="token punctuation">"</span></span>
<span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Name<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Age<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Email<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>th</span><span class="token punctuation">></span></span>Address<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>th</span><span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#body</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>{ rows }<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>tr</span> <span class="token attr-name">v-for</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>row in rows<span class="token punctuation">"</span></span> <span class="token attr-name">:key</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>row.guid<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.name }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.age }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.email }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>
        {{ row.address.street }},
        {{ row.address.city }}
        {{ row.address.state }}
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>tr</span><span class="token punctuation">></span></span>
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTable</span><span class="token punctuation">></span></span>
</code></pre><div class="highlight-lines"><br><br><br><br><div class="highlight-line">&nbsp;</div><br><br><br><br><br><br><br><br><br><div class="highlight-line">&nbsp;</div><br><br><br><br><br><br><br><div class="highlight-line">&nbsp;</div><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br></div><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br><span class="line-number">12</span><br><span class="line-number">13</span><br><span class="line-number">14</span><br><span class="line-number">15</span><br><span class="line-number">16</span><br><span class="line-number">17</span><br><span class="line-number">18</span><br><span class="line-number">19</span><br><span class="line-number">20</span><br><span class="line-number">21</span><br><span class="line-number">22</span><br><span class="line-number">23</span><br><span class="line-number">24</span><br><span class="line-number">25</span><br><span class="line-number">26</span><br><span class="line-number">27</span><br><span class="line-number">28</span><br><span class="line-number">29</span><br><span class="line-number">30</span><br><span class="line-number">31</span><br><span class="line-number">32</span><br><span class="line-number">33</span><br><span class="line-number">34</span><br><span class="line-number">35</span><br><span class="line-number">36</span><br><span class="line-number">37</span><br><span class="line-number">38</span><br><span class="line-number">39</span><br><span class="line-number">40</span><br><span class="line-number">41</span><br><span class="line-number">42</span><br><span class="line-number">43</span><br></div></div>  </CodeGroupItem>
<CodeGroupItem title="js">
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code><span class="token operator">&lt;</span>script<span class="token operator">></span>
<span class="token keyword">import</span> users <span class="token keyword">from</span> <span class="token string">'./users.json'</span>

<span class="token keyword">export</span> <span class="token keyword">default</span> <span class="token punctuation">{</span>
  name<span class="token operator">:</span> <span class="token string">'CustomFiltering'</span><span class="token punctuation">,</span>
  <span class="token function">data</span> <span class="token punctuation">(</span><span class="token punctuation">)</span> <span class="token punctuation">{</span>
    <span class="token keyword">return</span> <span class="token punctuation">{</span>
      users<span class="token punctuation">,</span>
      filters<span class="token operator">:</span> <span class="token punctuation">{</span>
        age<span class="token operator">:</span> <span class="token punctuation">{</span> value<span class="token operator">:</span> <span class="token punctuation">{</span> min<span class="token operator">:</span> <span class="token number">21</span><span class="token punctuation">,</span> max<span class="token operator">:</span> <span class="token number">22</span> <span class="token punctuation">}</span><span class="token punctuation">,</span> custom<span class="token operator">:</span> <span class="token keyword">this</span><span class="token punctuation">.</span>ageFilter <span class="token punctuation">}</span>
      <span class="token punctuation">}</span>
    <span class="token punctuation">}</span>
  <span class="token punctuation">}</span><span class="token punctuation">,</span>
  methods<span class="token operator">:</span> <span class="token punctuation">{</span>
    <span class="token function">ageFilter</span> <span class="token punctuation">(</span><span class="token parameter">filterValue<span class="token punctuation">,</span> row</span><span class="token punctuation">)</span> <span class="token punctuation">{</span>
      <span class="token keyword">return</span> row<span class="token punctuation">.</span>age <span class="token operator">>=</span> filterValue<span class="token punctuation">.</span>min <span class="token operator">&amp;&amp;</span> row<span class="token punctuation">.</span>age <span class="token operator">&lt;=</span> filterValue<span class="token punctuation">.</span>max
    <span class="token punctuation">}</span>
  <span class="token punctuation">}</span>
<span class="token punctuation">}</span>
<span class="token operator">&lt;</span><span class="token operator">/</span>script<span class="token operator">></span>
</code></pre><div class="highlight-lines"><br><br><br><br><br><br><br><br><div class="highlight-line">&nbsp;</div><div class="highlight-line">&nbsp;</div><div class="highlight-line">&nbsp;</div><br><br><div class="highlight-line">&nbsp;</div><div class="highlight-line">&nbsp;</div><div class="highlight-line">&nbsp;</div><div class="highlight-line">&nbsp;</div><br><br><br></div><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br><span class="line-number">12</span><br><span class="line-number">13</span><br><span class="line-number">14</span><br><span class="line-number">15</span><br><span class="line-number">16</span><br><span class="line-number">17</span><br><span class="line-number">18</span><br><span class="line-number">19</span><br><span class="line-number">20</span><br></div></div></CodeGroupItem>
</CodeGroup>
<div class="custom-container tip"><p class="custom-container-title">TIP</p>
<p>Notice how we have two inputs controlling the filter values. The <code>ageFilter</code> custom filter receives both of those values
and verify the row to make sure its age is between them.</p>
</div>
<h4 id="result-1"><a class="header-anchor" href="#result-1">#</a> Result</h4>
<CustomFiltering />
</template>