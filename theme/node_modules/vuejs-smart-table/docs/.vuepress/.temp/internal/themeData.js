export const themeData = {
  "navbar": [
    {
      "text": "Documentation",
      "link": "/getting-started.md"
    }
  ],
  "sidebar": [
    {
      "isGroup": true,
      "text": "Documentation",
      "children": [
        "/getting-started.md",
        "/the-basics.md",
        "/filtering.md",
        "/sorting.md",
        "/selection.md",
        "/table-state.md"
      ]
    }
  ],
  "locales": {
    "/": {
      "selectLanguageName": "English",
      "danger": "WARNING"
    }
  },
  "logo": null,
  "repo": null,
  "selectLanguageText": "Languages",
  "selectLanguageAriaLabel": "Select language",
  "editLink": true,
  "editLinkText": "Edit this page",
  "lastUpdated": true,
  "lastUpdatedText": "Last Updated",
  "contributors": true,
  "contributorsText": "Contributors",
  "notFound": [
    "There's nothing here.",
    "How did we get here?",
    "That's a Four-Oh-Four.",
    "Looks like we've got some broken links."
  ],
  "backToHome": "Take me home",
  "openInNewWindow": "open in new window"
}

if (import.meta.webpackHot) {
  import.meta.webpackHot.accept()
  if (__VUE_HMR_RUNTIME__.updateThemeData) {
    __VUE_HMR_RUNTIME__.updateThemeData(themeData)
  }
}

if (import.meta.hot) {
  import.meta.hot.accept(({ themeData }) => {
    __VUE_HMR_RUNTIME__.updateThemeData(themeData)
  })
}
