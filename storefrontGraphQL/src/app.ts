import "reflect-metadata";
import express, { NextFunction, Response, Request } from "express";
import {ApolloServer} from "apollo-server-express";
import {buildSchema} from 'type-graphql';
import { initializeDatabase } from "./config/db";
import pgSession from "connect-pg-simple";
import session from "express-session";


import { Pool } from "pg";

import "./config/passport.config";
import { Console } from "console";

async function main() 
{
  const schema = await buildSchema({
    resolvers: [__dirname + "/controllers/auth/**/*.ts"]
  });

  const apolloServer = new ApolloServer({
  schema,
  context: ({req, res}: any) => ({req, res}),

  });

  const app = express();

  await apolloServer.start();

  app.use((req:Request, res:Response, next:NextFunction) => {
    console.log("Hello!!!!!!");
    next();
    console.log("Got it!!!!");
  })
  apolloServer.applyMiddleware({app});

  app.listen(7000, (): void => {
    initializeDatabase();
    console.log(`App started on port: ${7000}  ...`);
  });
  
}

main();