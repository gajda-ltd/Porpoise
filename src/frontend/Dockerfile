FROM node:latest AS build
LABEL version="1.0"
WORKDIR /app
COPY ["package.json", "./"]
RUN npm install --production
COPY . .
RUN npm run build-legacy

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=build /app/build .
ENTRYPOINT ["nginx", "-g", "daemon off;"]
