<template><h1 id="sorting"><a class="header-anchor" href="#sorting">#</a> Sorting</h1>
<p>To enable column sorting, instead of using vanilla <code>th</code> elements we will use <code>VTh</code> components for the columns
we want to provide sorting.</p>
<h2 id="table-header"><a class="header-anchor" href="#table-header">#</a> Table Header <Badge text="VTh"/></h2>
<p>The <code>VTh</code> component renders to a regular <code>th</code> element, but it allows you to sort the table, it has three properties:
<code>sortKey</code>, <code>customSort</code> and <code>defaultSort</code>.</p>
<h3 id="sort-key"><a class="header-anchor" href="#sort-key">#</a> Sort Key <Badge text="string | function"/></h3>
<p>The <code>sortKey</code> property is used to get to specify the value within a row we will use to sort it. It can be a <code>string</code>
or a <code>function</code>.</p>
<h4 id="string"><a class="header-anchor" href="#string">#</a> String</h4>
<p>As a <code>string</code>, it represents the path to the property in the row we want to sort. You can even use nested paths.</p>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>name<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Name<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>address.state<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>State<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br></div></div><h4 id="function"><a class="header-anchor" href="#function">#</a> Function</h4>
<p>Sometimes you may want the sort value to be a computed value, for instance <code>firstName</code> + <code>lastName</code> or the length of a field.</p>
<p>For those cases you can use a <code>function</code> instead, its typescript definition is:</p>
<div class="language-typescript ext-ts line-numbers-mode"><pre v-pre class="language-typescript"><code><span class="token keyword">type</span> <span class="token class-name">SortKey</span> <span class="token operator">=</span> <span class="token punctuation">(</span>row<span class="token operator">:</span> <span class="token builtin">any</span><span class="token punctuation">,</span> sortOrder<span class="token operator">:</span> SortOrder<span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token builtin">any</span>

<span class="token keyword">enum</span> SortOrder <span class="token punctuation">{</span>
  <span class="token constant">DESC</span> <span class="token operator">=</span> <span class="token operator">-</span><span class="token number">1</span><span class="token punctuation">,</span>
  <span class="token constant">NONE</span> <span class="token operator">=</span> <span class="token number">0</span><span class="token punctuation">,</span>
  <span class="token constant">ASC</span><span class="token operator">=</span> <span class="token number">1</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br></div></div><p>Notice how the function receives two arguments:</p>
<ul>
<li><code>row</code>: Is the full object that represents the current row.</li>
<li><code>sortOrder</code>: Is the current sorting direction. This is just extra information you can use when computing the sort value.</li>
</ul>
<CodeGroup>
  <CodeGroupItem title="html" active>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">:sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>nameLength<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Name<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br></div></div>  </CodeGroupItem>
  <CodeGroupItem title="js">
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code>methods<span class="token operator">:</span> <span class="token punctuation">{</span>
  <span class="token function">nameLength</span> <span class="token punctuation">(</span><span class="token parameter">row</span><span class="token punctuation">)</span> <span class="token punctuation">{</span>
    <span class="token keyword">return</span> row<span class="token punctuation">.</span>name<span class="token punctuation">.</span>length
  <span class="token punctuation">}</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br></div></div>  </CodeGroupItem>
</CodeGroup>
<p>Once we have used the <code>sortKey</code> property to get the column values, we will proceed to compare them.</p>
<p>If the values are numbers, we will just compare them by subtraction.
Otherwise, we will call <code>toString()</code> on them and compare them with <code>localeCompare</code>.</p>
<h3 id="custom-sort"><a class="header-anchor" href="#custom-sort">#</a> Custom Sort <Badge text="function"/></h3>
<p>In some cases you need more control over sorting,
for instance if you have a complex object, or your sorting depends on two or more values.
For those instances, instead of providing a <code>sortKey</code> property you can use the <code>customSort</code> property to provide a sorting function.
The custom sort function has the following definition:</p>
<div class="language-typescript ext-ts line-numbers-mode"><pre v-pre class="language-typescript"><code><span class="token keyword">type</span> <span class="token class-name">CustomSort</span> <span class="token operator">=</span> <span class="token punctuation">(</span><span class="token punctuation">(</span>a<span class="token operator">:</span> <span class="token builtin">any</span><span class="token punctuation">,</span> b<span class="token operator">:</span> <span class="token builtin">any</span><span class="token punctuation">,</span> sortOrder<span class="token operator">:</span> SortOrder<span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token builtin">number</span><span class="token punctuation">)</span>

<span class="token keyword">enum</span> SortOrder <span class="token punctuation">{</span>
  <span class="token constant">DESC</span> <span class="token operator">=</span> <span class="token operator">-</span><span class="token number">1</span><span class="token punctuation">,</span>
  <span class="token constant">NONE</span> <span class="token operator">=</span> <span class="token number">0</span><span class="token punctuation">,</span>
  <span class="token constant">ASC</span><span class="token operator">=</span> <span class="token number">1</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br></div></div><p>The function will receive the 2 rows being compared, and a third parameter with the sort order.</p>
<p>The function needs to return  greater than <code>0</code> if the first row is greater, lower than <code>0</code> if the second row is greater
or <code>0</code> if they are the same.</p>
<CodeGroup>
  <CodeGroupItem title="html" active>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">:customSort</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>dateSort<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Registered at<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br></div></div>  </CodeGroupItem>
  <CodeGroupItem title="js" active>
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code>methods<span class="token operator">:</span> <span class="token punctuation">{</span>
  <span class="token function">dateSort</span><span class="token punctuation">(</span><span class="token parameter">a<span class="token punctuation">,</span> b<span class="token punctuation">,</span> sortOrder</span><span class="token punctuation">)</span> <span class="token punctuation">{</span>
    <span class="token keyword">let</span> date1 <span class="token operator">=</span> <span class="token keyword">new</span> <span class="token class-name">Date</span><span class="token punctuation">(</span>a<span class="token punctuation">.</span>registered<span class="token punctuation">)</span><span class="token punctuation">.</span><span class="token function">getTime</span><span class="token punctuation">(</span><span class="token punctuation">)</span><span class="token punctuation">;</span>
    <span class="token keyword">let</span> date2 <span class="token operator">=</span> <span class="token keyword">new</span> <span class="token class-name">Date</span><span class="token punctuation">(</span>b<span class="token punctuation">.</span>registered<span class="token punctuation">)</span><span class="token punctuation">.</span><span class="token function">getTime</span><span class="token punctuation">(</span><span class="token punctuation">)</span><span class="token punctuation">;</span>

    <span class="token keyword">return</span> date1 <span class="token operator">-</span> date2 <span class="token operator">*</span> sortOrder<span class="token punctuation">;</span>
  <span class="token punctuation">}</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br></div></div>  </CodeGroupItem>
</CodeGroup>
<h3 id="default-sort"><a class="header-anchor" href="#default-sort">#</a> Default Sort <Badge text="'asc' | 'desc'"/></h3>
<p>You should provide this for the one column you want the table to be sorted by default.
The possible values are: <code>asc</code> for ascending ordering and <code>desc</code> for descending order.</p>
<p>Only one <code>VTh</code> should have its <code>defaultSort</code> value set, if more than one have it, the last one will take precedence.</p>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>name<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Name<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>age<span class="token punctuation">"</span></span> <span class="token attr-name">defaultSort</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>desc<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Age<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br></div></div><h3 id="example"><a class="header-anchor" href="#example">#</a> Example</h3>
<CodeGroup>
  <CodeGroupItem title="html" active>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTable</span> <span class="token attr-name">:data</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>users<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#head</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">:sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>nameLength<span class="token punctuation">"</span></span> <span class="token attr-name">defaultSort</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>desc<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
          Name
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>age<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Age<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>address.state<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>State<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">:customSort</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>dateSort<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>Registered at<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>template</span> <span class="token attr-name">#body</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>{ rows }<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>tr</span> <span class="token attr-name">v-for</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>row in rows<span class="token punctuation">"</span></span> <span class="token attr-name">:key</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>row.guid<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.name }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.age }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.address.state }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
          <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>td</span><span class="token punctuation">></span></span>{{ row.registered }}<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>td</span><span class="token punctuation">></span></span>
        <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>tr</span><span class="token punctuation">></span></span>
      <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
    <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTable</span><span class="token punctuation">></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>template</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br><span class="line-number">12</span><br><span class="line-number">13</span><br><span class="line-number">14</span><br><span class="line-number">15</span><br><span class="line-number">16</span><br><span class="line-number">17</span><br><span class="line-number">18</span><br><span class="line-number">19</span><br><span class="line-number">20</span><br></div></div>  </CodeGroupItem>
  <CodeGroupItem title="js">
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code><span class="token operator">&lt;</span>script<span class="token operator">></span>
<span class="token keyword">import</span> users <span class="token keyword">from</span> <span class="token string">'./users.json'</span>

<span class="token keyword">export</span> <span class="token keyword">default</span> <span class="token punctuation">{</span>
  name<span class="token operator">:</span> <span class="token string">'Sorting'</span><span class="token punctuation">,</span>
  <span class="token function-variable function">data</span><span class="token operator">:</span> <span class="token punctuation">(</span><span class="token punctuation">)</span> <span class="token operator">=></span> <span class="token punctuation">(</span><span class="token punctuation">{</span>
    users
  <span class="token punctuation">}</span><span class="token punctuation">)</span><span class="token punctuation">,</span>
  methods<span class="token operator">:</span> <span class="token punctuation">{</span>
    <span class="token function">nameLength</span> <span class="token punctuation">(</span><span class="token parameter">row</span><span class="token punctuation">)</span> <span class="token punctuation">{</span>
      <span class="token keyword">return</span> row<span class="token punctuation">.</span>name<span class="token punctuation">.</span>length
    <span class="token punctuation">}</span><span class="token punctuation">,</span>
    <span class="token function">dateSort</span><span class="token punctuation">(</span><span class="token parameter">a<span class="token punctuation">,</span> b</span><span class="token punctuation">)</span> <span class="token punctuation">{</span>
      <span class="token keyword">let</span> date1 <span class="token operator">=</span> <span class="token keyword">new</span> <span class="token class-name">Date</span><span class="token punctuation">(</span>a<span class="token punctuation">.</span>registered<span class="token punctuation">)</span><span class="token punctuation">.</span><span class="token function">getTime</span><span class="token punctuation">(</span><span class="token punctuation">)</span><span class="token punctuation">;</span>
      <span class="token keyword">let</span> date2 <span class="token operator">=</span> <span class="token keyword">new</span> <span class="token class-name">Date</span><span class="token punctuation">(</span>b<span class="token punctuation">.</span>registered<span class="token punctuation">)</span><span class="token punctuation">.</span><span class="token function">getTime</span><span class="token punctuation">(</span><span class="token punctuation">)</span><span class="token punctuation">;</span>
      
      <span class="token keyword">return</span> date1 <span class="token operator">-</span> date2<span class="token punctuation">;</span>
    <span class="token punctuation">}</span>
  <span class="token punctuation">}</span>
<span class="token punctuation">}</span>
<span class="token operator">&lt;</span><span class="token operator">/</span>script<span class="token operator">></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br><span class="line-number">12</span><br><span class="line-number">13</span><br><span class="line-number">14</span><br><span class="line-number">15</span><br><span class="line-number">16</span><br><span class="line-number">17</span><br><span class="line-number">18</span><br><span class="line-number">19</span><br><span class="line-number">20</span><br><span class="line-number">21</span><br></div></div>  </CodeGroupItem>
</CodeGroup>
<Sorting />
<h2 id="custom-sort-icons"><a class="header-anchor" href="#custom-sort-icons">#</a> Custom Sort Icons</h2>
<p>By default, we include three SVG icons to indicate the sorting state of a column.
This should be enough for basic examples, but you have the ability to provide your own sort icons.</p>
<p>The first thing you need to do is to disable the default sort icons with the <code>hideSortIcons</code> property on the <code>VTable</code> component:</p>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTable</span>
    <span class="token attr-name">:data</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>users<span class="token punctuation">"</span></span>
    <span class="token attr-name">:hideSortIcons</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>true<span class="token punctuation">"</span></span>
<span class="token punctuation">></span></span>
...
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTable</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br></div></div><p>Then, the <code>VTh</code> component's default slot receives a <code>sortOrder</code> property you can use to include your custom sort icon.
For instance, if you were to use <a href="https://fontawesome.com/" target="_blank" rel="noopener noreferrer">FontAwesome<OutboundLink/></a> icons it would look like this:</p>
<div class="language-html ext-html line-numbers-mode"><pre v-pre class="language-html"><code><span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>VTh</span> <span class="token attr-name">sortKey</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>name<span class="token punctuation">"</span></span> <span class="token attr-name">#default</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>{ sortOrder }<span class="token punctuation">"</span></span><span class="token punctuation">></span></span>
  Name
  <span class="token tag"><span class="token tag"><span class="token punctuation">&lt;</span>i</span> 
    <span class="token attr-name">class</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>fas<span class="token punctuation">"</span></span> 
    <span class="token attr-name">:class</span><span class="token attr-value"><span class="token punctuation attr-equals">=</span><span class="token punctuation">"</span>{ 
       <span class="token punctuation">'</span>fa-sort<span class="token punctuation">'</span>: sortOrder === 0, 
       <span class="token punctuation">'</span>fa-up<span class="token punctuation">'</span>: sortOrder === 1, 
       <span class="token punctuation">'</span>fa-down<span class="token punctuation">'</span>: sortOrder === -1, 
    }<span class="token punctuation">"</span></span>
  <span class="token punctuation">/></span></span>
<span class="token tag"><span class="token tag"><span class="token punctuation">&lt;/</span>VTh</span><span class="token punctuation">></span></span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br><span class="line-number">6</span><br><span class="line-number">7</span><br><span class="line-number">8</span><br><span class="line-number">9</span><br><span class="line-number">10</span><br><span class="line-number">11</span><br></div></div><p>Remember, <code>SortOrder</code> is defined as:</p>
<div class="language-typescript ext-ts line-numbers-mode"><pre v-pre class="language-typescript"><code><span class="token keyword">enum</span> SortOrder <span class="token punctuation">{</span>
  <span class="token constant">DESC</span> <span class="token operator">=</span> <span class="token operator">-</span><span class="token number">1</span><span class="token punctuation">,</span>
  <span class="token constant">NONE</span> <span class="token operator">=</span> <span class="token number">0</span><span class="token punctuation">,</span>
  <span class="token constant">ASC</span><span class="token operator">=</span> <span class="token number">1</span>
<span class="token punctuation">}</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br><span class="line-number">4</span><br><span class="line-number">5</span><br></div></div><p>In practice, you don't want to repeat this over and over,
so you will want to create a custom component that receives the <code>sortOrder</code> and renders the right icon.</p>
<h2 id="sort-events"><a class="header-anchor" href="#sort-events">#</a> Sort Events</h2>
<h3 id="sort-changed"><a class="header-anchor" href="#sort-changed">#</a> Sort Changed</h3>
<p>When the sort changes because the user clicks a header we will emit a <code>sortChanged</code> event. The event payload will
be an object with a <code>sortOrder</code> property whose value will be <code>-1</code> for descending or <code>1</code> for ascending.</p>
</template>