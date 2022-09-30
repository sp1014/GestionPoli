export const data = {
  "key": "v-5dc4b15a",
  "path": "/getting-started.html",
  "title": "Getting Started",
  "lang": "en-US",
  "frontmatter": {},
  "excerpt": "",
  "headers": [
    {
      "level": 3,
      "title": "Why Smart Table",
      "slug": "why-smart-table",
      "children": []
    },
    {
      "level": 3,
      "title": "Installation",
      "slug": "installation",
      "children": []
    },
    {
      "level": 3,
      "title": "For Vue 2",
      "slug": "for-vue-2",
      "children": []
    }
  ],
  "filePathRelative": "getting-started.md",
  "git": {
    "updatedTime": 1619183832000,
    "contributors": [
      {
        "name": "Hector Romero",
        "email": "hromero.mx@gmail.com",
        "commits": 4
      }
    ]
  }
}

if (import.meta.webpackHot) {
  import.meta.webpackHot.accept()
  if (__VUE_HMR_RUNTIME__.updatePageData) {
    __VUE_HMR_RUNTIME__.updatePageData(data)
  }
}

if (import.meta.hot) {
  import.meta.hot.accept(({ data }) => {
    __VUE_HMR_RUNTIME__.updatePageData(data)
  })
}
