export const data = {
  "key": "v-316ce4e8",
  "path": "/filtering.html",
  "title": "Filtering",
  "lang": "en-US",
  "frontmatter": {},
  "excerpt": "",
  "headers": [
    {
      "level": 2,
      "title": "Filters",
      "slug": "filters",
      "children": []
    },
    {
      "level": 2,
      "title": "Basic Filters",
      "slug": "basic-filters",
      "children": [
        {
          "level": 3,
          "title": "value",
          "slug": "value",
          "children": []
        },
        {
          "level": 3,
          "title": "keys",
          "slug": "keys",
          "children": []
        },
        {
          "level": 3,
          "title": "exact",
          "slug": "exact",
          "children": []
        }
      ]
    },
    {
      "level": 2,
      "title": "Custom Filters",
      "slug": "custom-filters",
      "children": [
        {
          "level": 3,
          "title": "value",
          "slug": "value-1",
          "children": []
        },
        {
          "level": 3,
          "title": "custom",
          "slug": "custom",
          "children": []
        }
      ]
    }
  ],
  "filePathRelative": "filtering.md",
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
