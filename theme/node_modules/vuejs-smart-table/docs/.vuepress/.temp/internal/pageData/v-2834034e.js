export const data = {
  "key": "v-2834034e",
  "path": "/sorting.html",
  "title": "Sorting",
  "lang": "en-US",
  "frontmatter": {},
  "excerpt": "",
  "headers": [
    {
      "level": 2,
      "title": "Table Header",
      "slug": "table-header",
      "children": [
        {
          "level": 3,
          "title": "Sort Key",
          "slug": "sort-key",
          "children": []
        },
        {
          "level": 3,
          "title": "Custom Sort",
          "slug": "custom-sort",
          "children": []
        },
        {
          "level": 3,
          "title": "Default Sort",
          "slug": "default-sort",
          "children": []
        },
        {
          "level": 3,
          "title": "Example",
          "slug": "example",
          "children": []
        }
      ]
    },
    {
      "level": 2,
      "title": "Custom Sort Icons",
      "slug": "custom-sort-icons",
      "children": []
    },
    {
      "level": 2,
      "title": "Sort Events",
      "slug": "sort-events",
      "children": [
        {
          "level": 3,
          "title": "Sort Changed",
          "slug": "sort-changed",
          "children": []
        }
      ]
    }
  ],
  "filePathRelative": "sorting.md",
  "git": {
    "updatedTime": 1619788566000,
    "contributors": [
      {
        "name": "Hector Romero",
        "email": "hromero.mx@gmail.com",
        "commits": 3
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
