export const data = {
  "key": "v-8daa1a0e",
  "path": "/",
  "title": "",
  "lang": "en-US",
  "frontmatter": {
    "home": true,
    "actions": [
      {
        "text": "Documentation →",
        "link": "/getting-started.md",
        "type": "primary"
      }
    ],
    "features": [
      {
        "title": "Simple to use",
        "details": "Using Vue Smart Table is almost like using a regular HTML table and with very little effort you will get a lot out of it."
      },
      {
        "title": "Standard HTML Table",
        "details": "The output of Vue Smart Table is a standard HTML table. We make no styling assumptions, so you can easily style however you desire."
      },
      {
        "title": "Feature Packed",
        "details": "Out of the box you will get filtering, sorting, pagination and row selection."
      }
    ]
  },
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
    }
  ],
  "filePathRelative": "README.md",
  "git": {
    "updatedTime": 1619788972000,
    "contributors": [
      {
        "name": "hromero",
        "email": "hromero@granburyrs.com",
        "commits": 5
      },
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
