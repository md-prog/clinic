const path = require('path');
var webpack = require('webpack');

module.exports = {
    entry: {
        'bundle.client': [
        path.join(__dirname, 'VueApp/client.js')]
    },
    output: {
        path: path.join(__dirname, 'wwwroot/dist'),
        publicPath: '/dist/',
        filename: '[name].js',
    },
    resolve: {
        extensions: ['.js', '.json', '.css', '.scss', '.html']
    },
    module: {
        loaders: [
          {
              test: /\.vue$/,
              loader: 'vue-loader',
          },
          //{
          //    test: /tether\.js$/,
          //    loader: "expose-loader?Tether"
          //},
          {
              test: /\.js$/,
              loader: 'babel-loader',
              include: __dirname,
              exclude: /node_modules/
          },
            { test: /\.json$/, loader: 'json-loader', query: { silent: true } },
            {
                test: /\.html$/, loader: 'raw-loader',
                exclude: /\.async\.html$/
            },
            {
                test: /\.(png|jpg|jpeg|gif|svg)$/,
                loader: 'file-loader',
                query: {
                    limit: 10000,
                    name: 'img/[name]-[sha512:hash:base64:7].[ext]'
                }
            },
            {
                test: /\.(ico)$/,
                loader: 'file-loader',
                query: {
                    limit: 10000,
                    name: '[name].[ext]'
                }
            },
            {
                test: /\.css$/,
                loaders: ["style-loader", "css-loader"],
                exclude: /node_modules/
            },
            {
                test: /\.scss$/,
                loaders: ["style-loader", "css-loader", "sass-loader"],
                exclude: /node_modules/
            },
              {
                  test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
                  loader: "url-loader?limit=10000&mimetype=application/font-woff"
              },
              {
                  test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "file-loader"
              },
            {
                test: require.resolve("pace-progress"),
                loader: "imports-loader?define=>false"
            }
        ]
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            "window.$": "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery",
            Tether: "tether",
            tether: "tether",
            "window.Tether": "tether",
            Tooltip: "exports-loader?Tooltip!bootstrap/js/dist/tooltip",
            Alert: "exports-loader?Alert!bootstrap/js/dist/alert",
            Button: "exports-loader?Button!bootstrap/js/dist/button",
            Carousel: "exports-loader?Carousel!bootstrap/js/dist/carousel",
            Collapse: "exports-loader?Collapse!bootstrap/js/dist/collapse",
            Dropdown: "exports-loader?Dropdown!bootstrap/js/dist/dropdown",
            Modal: "exports-loader?Modal!bootstrap/js/dist/modal",
            Popover: "exports-loader?Popover!bootstrap/js/dist/popover",
            Scrollspy: "exports-loader?Scrollspy!bootstrap/js/dist/scrollspy",
            Tab: "exports-loader?Tab!bootstrap/js/dist/tab",
            Tooltip: "exports-loader?Tooltip!bootstrap/js/dist/tooltip",
            Util: "exports-loader?Util!bootstrap/js/dist/util",
        }),
        new webpack.ProvidePlugin({
            moment: "moment"
        })
    ]
};
