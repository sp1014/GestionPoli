export const data = {
  "key": "v-71c35302",
  "path": "/the-basics.html",
  "title": "The Basics",
  "lang": "en-US",
  "frontmatter": {},
  "excerpt": "",
  "headers": [
    {
      "level": 2,
      "title": "VTable",
      "slug": "vtable",
      "children": [
        {
          "level": 3,
          "title": "Data",
          "slug": "data",
          "children": []
        },
        {
          "level": 3,
          "title": "Head",
          "slug": "head",
          "children": []
        },
        {
          "level": 3,
          "title": "Body",
          "slug": "body",
          "children": []
        }
      ]
    }
  ],
  "filePathRelative": "the-basics.md",
  "git": {
    "updatedTime": 1619183606000,
    "contributors": [
      {
        "name": "Hector Romero",
        "email": "hromero.mx@gmail.com",
        "commits": 2
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
