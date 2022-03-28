FROM node:16.13.0-alpine as node
WORKDIR /app
COPY . /app
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/galactus-ui /usr/share/nginx/html