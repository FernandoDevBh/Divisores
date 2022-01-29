import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

export abstract class BaseService {
    protected readonly baseUrl: string = environment.apiUrl;

    constructor(protected http: HttpClient) { }

    protected createUrl(endpoint: string): string {
        return `${this.baseUrl}${endpoint}`;
    }
}