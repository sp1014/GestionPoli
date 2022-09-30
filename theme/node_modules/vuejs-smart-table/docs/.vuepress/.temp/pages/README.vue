<template><h3 id="why-smart-table"><a class="header-anchor" href="#why-smart-table">#</a> Why Smart Table</h3>
<p>There are a lot of Data Table plugins out there, some of them are very good but pretty much all of them are very complicated to use.
What I really wanted was the simplicity of a vanilla HTML table but with the power of the more complex Data Table plugins.</p>
<p>Vue Smart Table is the answer to that need. Creating a Smart Table is almost as simply as creating a Vanilla HTML Table.
When you need it, you can enable extra functionality in a way that feels natural. It is very straight forward, you can learn everything you need to know on one sit.</p>
<h3 id="installation"><a class="header-anchor" href="#installation">#</a> Installation</h3>
<p>To install simply run</p>
<div class="language-text ext-text line-numbers-mode"><pre v-pre class="language-text"><code>npm add vuejs-smart-table@next
</code></pre><div class="line-numbers"><span class="line-number">1</span><br></div></div><p>or</p>
<div class="language-text ext-text line-numbers-mode"><pre v-pre class="language-text"><code>yarn add vuejs-smart-table@next
</code></pre><div class="line-numbers"><span class="line-number">1</span><br></div></div><p>Then in your <code>main.js</code></p>
<div class="language-javascript ext-js line-numbers-mode"><pre v-pre class="language-javascript"><code><span class="token keyword">import</span> SmartTable <span class="token keyword">from</span> <span class="token string">'vuejs-smart-table'</span>

Vue<span class="token punctuation">.</span><span class="token function">use</span><span class="token punctuation">(</span>SmartTable<span class="token punctuation">)</span>
</code></pre><div class="line-numbers"><span class="line-number">1</span><br><span class="line-number">2</span><br><span class="line-number">3</span><br></div></div><p>This will globally register four Components: <code>VTable</code>, <code>VTh</code>, <code>VTr</code> and <code>VTPagination</code></p>
<p>Next learn how to create a <RouterLink to="/the-basics.html">basic table</RouterLink></p>
</template>