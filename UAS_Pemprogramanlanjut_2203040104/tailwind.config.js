/** @type {import('tailwindcss').Config} */
module.exports = {
    purge: [
        './**/*.aspx',
        './**/*.ascx',
        './**/*.master',
        './**/**/*.aspx',
        './**/**/*.ascx',
        './**/**/*.master'
    ],
    theme: {
        extend: {
            colors: {
                'sagegreen': '#658864',
                'cloverlane': '#b7b78a',
                'lightgray': '#dddddd',
                'whitesmoke': '#eeeeee'
            },
            fontFamily: {
                logo: ['Laila', 'sans-serif'],
                primary: ['Inter', 'sans-serif'],
                secondary: ['Poppins', 'sans-serif']
            },
      },
  },
    plugins: [
    ],
}

