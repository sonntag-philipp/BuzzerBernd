module.exports = {
  purge: {
    enabled: false,
    content: ["./**/*.html", "./**/*.razor", "./**/*.razor.css"],
  },
  darkMode: false, // or 'media' or 'class'
  theme: {
    container: {
      center: true,
    },
  },
  variants: {
    extend: {
        backgroundColor: [
            "active"
        ]
    },
  },
  plugins: [],
};
