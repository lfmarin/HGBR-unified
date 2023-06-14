import { Stack, Link, Typography } from "@mui/material";

export default function MuiLink(props){
    return (
        <Stack spacing={1} direction={'row'} m={4}>
            <Link href={props.linkPath}>Buscar</Link>
        </Stack>
    )
}