    import { HttpClient } from '@angular/common/http';
    import { Injectable } from '@angular/core';

    @Injectable({
      providedIn: 'root'
    })
    export class AssetService {
      baseUrl = 'https://localhost:7236/api/';

      constructor(private http: HttpClient) { }

      getAssets() {
        return this.http.get(this.baseUrl + 'assets');
      }
    }
    
