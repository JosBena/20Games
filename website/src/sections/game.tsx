
import {Unity, useUnityContext} from "react-unity-webgl";

const Game = () => {
    let here = "20Games/Builds/Games/Build/";
    let remote = "Builds/Games/Build/2"
    const path = remote;
    
    const { unityProvider } = useUnityContext({
        loaderUrl: path + "Games.loader.js",
        dataUrl: path + "Games.data.unityweb",
        frameworkUrl: path + "Games.framework.js.unityweb",
        codeUrl: path +"Games.wasm.unityweb",
        });
    return (
        <div>
            <Unity unityProvider={unityProvider} />
        </div>
    )

}
//npm run deploy -- -m "Deploy React app to GitHub Pages"
export default Game;
